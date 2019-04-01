#include "stdafx.h"
#include <iostream>
#include <thread>
#include <future>
#include "BlockingQueue.h"

class Motion
{
private:
	int axis;
	double range;
	double speed;
public:
	Motion(int axis, double range, double speed) {}
	~Motion() {}
};

bool BGo(int axis,double range,double speed)
{

	Motion* item;
	
	item= new Motion(axis, range, speed);

	queue.Put(item);
}




int main(int argc, char* argv[])
{
	BlockingQueue<int> q;
	auto producer = std::async(std::launch::async, [&q]() {
		for (int i = 0; i < 100; ++i) {
			q.Put(i);
		}
	});

	auto consumer = std::async(std::launch::async, [&q]() {
		while (q.Size()) {
			std::cout << q.Take() << std::endl;
		}
	});



	producer.wait();
	consumer.wait();

	return 0;
}