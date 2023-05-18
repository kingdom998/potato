#include <stdlib.h>
#include <stdio.h>
#include "test.h"

int main( void )
{
    

	if (init())
	{
		callFun();
	}

	uninit();
    
    system("Pause");

    return 0;
}