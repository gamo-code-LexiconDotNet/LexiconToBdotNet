#include <iostream>

#ifdef _WIN32

#include "Tasks.h"
int main()
{
    Tasks tasks;
    tasks.Run();
}

#else

int main()
{
    std::cout << "Compile on windows platform (WIN32) to run" << std::endl;
}

#endif