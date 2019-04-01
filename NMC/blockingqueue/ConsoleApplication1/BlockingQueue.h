#include <condition_variable>
#include <queue>
#include <assert.h>

const unsigned int MaxQueueCount = 50;
BlockingQueue<Motion*> queue;

template<class T>
class BlockingQueue
{
public:
	BlockingQueue() : _mutex(), _condvar(), _queue()
	{
	}

	void Put(const T& task)
	{
		{
			std::unique_lock<std::mutex> lock(_mutex);
			_condvar.wait(lock, [this] { return !(_queue.size() < MaxQueueCount); }); //lock until the queue is not full
			
			_queue.push(task);

			
		}
		_condvar.notify_all();
	}

	T Take()
	{
		std::unique_lock<std::mutex> lock(_mutex);
		_condvar.wait(lock, [this] {return !_queue.empty(); });//lock until the queue is not empty
		assert(!_queue.empty());
		T front(_queue.front());
		_queue.pop();

		return front;
	}

	size_t Size() const
	{
		std::lock_guard<std::mutex> lock(_mutex);
		return _queue.size();
	}

	void InitProducerThread()
	{
		std::thread ProducerThread(Put);
		std::thread ComsumerThread(Take);
	}


private:
	mutable std::mutex _mutex;
	std::condition_variable _condvar;
	std::queue<T> _queue;
};