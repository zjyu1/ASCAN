using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum ReceiverActive
    {
        OFF = 0,
        ON = 1
    }

    public enum FilterCutoffFreq
    {
        FilterPassAway = 0,   //直通
        FilterD5KHZ,//0D5KHz
        Filter1MHZ, //1MHz
        Filter1D5MHZ,			           
        Filter2MHZ,			      
        Filter2D5MHZ,			    
        Filter3MHZ,			    
        Filter3D5MHZ,			     
        Filter4MHZ,			    	
        Filter4D5MHZ,			     
        Filter5MHZ,			    	   
        Filter5D5MHZ,			    
        Filter6MHZ,			    	  
        Filter6D5MHZ,			       
        Filter7MHZ,			    
        Filter7D5MHZ,			        
        Filter8MHZ,			    	
        Filter8D5MHZ,			           
        Filter9MHZ,			    	 
        Filter9D5MHZ,			    	
        Filter10MHZ,			    	
        Filter10D5MHZ,			       
        Filter11MHZ,			    	
        Filter11D5MHZ,			   
        Filter12MHZ,			    	 
        Filter12D5MHZ,			      
        Filter13MHZ,			    	  
        Filter13D5MHZ,			    
        Filter14MHZ,			    	 
        Filter14D5MHZ,			       
        Filter15MHZ,			    	   
        Filter15D5MHZ,			      
        Filter16MHZ,			    	 
        Filter16D5MHZ,			       
        Filter17MHZ,			    	 
        Filter17D5MHZ,			   
        Filter18MHZ,			    
        Filter18D5MHZ,			    
        Filter19MHZ,			    	
        Filter19D5MHZ,			     
        Filter20MHZ,			    	
        Filter20D5MHZ,			     
        Filter21MHZ,			    	   
        Filter21D5MHZ,			      
        Filter22MHZ,			    	  
        Filter22D5MHZ,			      
        Filter23MHZ,		    	   
        Filter23D5MHZ,			       
        Filter24MHZ,			    	 
        Filter24D5MHZ,			       
        Filter25MHZ,		    	   
    }

    public enum ReceiverPATH
    {
        Normal = 0,//正常超声回波信号
        Testin = 1,//TESTIN 输入 
        Hvsense = 2//高压脉冲采样  
    }

    public enum DampingActive
    {
        OFF = 0,
        ON = 1,
    }
}
