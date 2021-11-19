#pragma once

#include <Windows.h>
#include <vector>

class Tasks {
public:
	void Run();
	void Hello();
	void Name();
	void Color();
	void Today();
	void Max();
	void Guess();
	void Save();
	void Read();
	void Roots();
	void Table();
	void Sort();
	void Palindrome();
	void Between();
	void OddEven();
	void Sum();
	void Game();
private:
	// For function 3
	HANDLE hConsole;
	WORD consoleAttr = 0;

	// helper functions
	int32_t maxh(int32_t, int32_t);
	void readCsvInput(std::vector<int>&);
	template<typename T> void bubbleSort(std::vector<T>&);
	template<typename T> void printVector(std::vector<T>);
};
