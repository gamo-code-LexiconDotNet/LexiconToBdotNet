#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>
#include <Windows.h>
#include <random>
#include "Tasks.h"
#include "Character.h"

/**
* Menu, Driver and Settings
*/
void Tasks::Run()
{
	std::srand(static_cast<unsigned int>(std::time(nullptr)));
	std::setlocale(LC_ALL, "sv_SE.UTF-8");
	hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

	std::wstring buff;
	int choice;

	while (1) {
		std::wcout << L"Välj funktion" << std::endl;
		std::wcout << L"1)  Hello World" << std::endl;
		std::wcout << L"2)  Namn" << std::endl;
		std::wcout << L"3)  Terminal" << std::endl;
		std::wcout << L"4)  Datum" << std::endl;
		std::wcout << L"5)  Max" << std::endl;
		std::wcout << L"6)  Gissa" << std::endl;
		std::wcout << L"7)  Spara till fil" << std::endl;
		std::wcout << L"8)  Läs från fil" << std::endl;
		std::wcout << L"9)  Rötter" << std::endl;
		std::wcout << L"10) Tabell" << std::endl;
		std::wcout << L"11) Sortera" << std::endl;
		std::wcout << L"12) Palindrom" << std::endl;
		std::wcout << L"13) Mellan" << std::endl;
		std::wcout << L"14) Jämt och Udda" << std::endl;
		std::wcout << L"15) Summera" << std::endl;
		std::wcout << L"16) Spel" << std::endl;
		std::wcout << L"0)  Avsluta" << std::endl;
		std::wcout << L"> ";
		std::wcin >> buff;
		std::wcout << std::endl << std::endl;

		try {
			choice = std::stoi(buff);
		}
		catch (...) {
			choice = -1;
		}

		system("cls");

		switch (choice)
		{
			case 0: exit(1); break;
			case 1: Tasks::Hello(); break;
			case 2: Tasks::Name(); break;
			case 3: Tasks::Color(); break;
			case 4: Tasks::Today(); break;
			case 5: Tasks::Max(); break;
			case 6: Tasks::Guess(); break;
			case 7: Tasks::Save(); break;
			case 8: Tasks::Read(); break;
			case 9: Tasks::Roots(); break;
			case 10: Tasks::Table(); break;
			case 11: Tasks::Sort(); break;
			case 12: Tasks::Palindrome(); break;
			case 13: Tasks::Between(); break;
			case 14: Tasks::OddEven(); break;
			case 15: Tasks::Sum(); break;
			case 16: Tasks::Game(); break;
			default: break;
		}

		std::wcout << std::endl;
	}
}

/**
* Function 1
* Print string
*/
void Tasks::Hello()
{
	std::cout << "Hello World!" << std::endl;
}

/**
* Function 2
* Take input and print out
*/
void Tasks::Name()
{
	std::wstring fname, lname, age;

	std::wcout << L"Förnamn\n> ";
	std::wcin >> fname;
	std::wcout << L"Efternamn\n> ";
	std::wcin >> lname;
	std::wcout << L"Ålder\n> ";
	std::wcin >> age;

	std::wcout << L"Du heter " << fname << L" " << lname << L" och är " << age << L" år gammal." << std::endl;
}

/**
* Function 3
* Change terminal foreground color and change back
*/
void Tasks::Color()
{
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

	if (consoleAttr == 0) {
		if (GetConsoleScreenBufferInfo(hConsole, &csbi))
			consoleAttr = csbi.wAttributes;
		SetConsoleTextAttribute(hConsole, FOREGROUND_RED);
	}
	else {
		SetConsoleTextAttribute(hConsole, consoleAttr);
		consoleAttr = 0;
	}
}

/**
* Function 4
* Print todays date
*/
void Tasks::Today()
{
	const std::time_t time = std::time(nullptr);
	std::tm tm = {};
	::localtime_s(&tm, &time);
	std::cout << std::put_time(&tm, "%F") << std::endl;
}

/**
* Function 5
* Take inputs and print largest
*/
void Tasks::Max()
{
	std::wstring buff1, buff2;
	int32_t a, b;

	std::wcout << L"Skriva in två nummer (mellanslags-separerade)\n> ";
	std::wcin >> buff1 >> buff2;

	try {
		a = std::stoi(buff1);
		b = std::stoi(buff2);
		std::wcout << maxh(a, b) << std::endl;
	}
	catch (...) {
		system("cls");
		std::wcout << L"Du måste skriva in två nummer." << std::endl;
	}
}

/**
* Function 5 helper
* Returns max of two numbers
*/
int32_t Tasks::maxh(int32_t a, int32_t b)
{
	return (a < b ? b : a);
}

/**
* Function 6
* Guess a number
*/
void Tasks::Guess()
{
	uint32_t num;
	uint32_t guess;
	uint32_t guesses = 1;
	std::wstring buff;

	num = (std::rand() % 100) + 1;

	while (1) {
		if (guesses < 2)
			std::wcout << L"Gissa ett tal\n> ";
		else
			std::wcout << L"Gissa igen\n> ";
		std::wcin >> buff;

		try {
			guess = std::stoi(buff);
		}
		catch (...) {
			std::wcout << L"Du måste gissa ett tal." << std::endl;
			continue;
		}

		if (guess == num) {
			std::wcout << L"Rätt efter " << guesses << L" försök." << std::endl;
			break;
		}
		else if (num < guess)
			std::wcout << L"Talet är mindre." << std::endl;
		else
			std::wcout << L"Talet är större." << std::endl;

		guesses++;
	}
}

/**
* Function 7
* Save string to file from input
*/
void Tasks::Save()
{
	std::wstring buff;
	std::wofstream file;

	file.open("file.txt", std::ios::trunc);

	if (file.is_open()) {
		std::wcout << L"Skriv in vad du vill spara till filen\n> ";
		std::wcin >> buff;
		file << buff;
	}
	else
		std::wcout << L"Kunde inte öppna filen...avslutar." << std::endl;

	file.close();
}

/**
* Function 8
* Read a string from file and print
*/
void Tasks::Read()
{
	std::wstring buff;
	std::wifstream file;

	file.open("file.txt");

	if (file.is_open()) {
		std::getline(file, buff);
		std::wcout << buff << std::endl;
	}
	else
		std::wcout << L"Kunde inte öppna filen...avslutar." << std::endl;

	file.close();
}

/**
* Function 9
* Take input and print square root, squareand  power of 10
*/
void Tasks::Roots()
{
	std::wstring buff;
	float num;

	std::wcout << L"Skriv in ett nummer\n> ";
	std::wcin >> buff;

	try {
		num = std::stof(buff);
	}
	catch (...) {
		system("cls");
		std::wcout << L"Du måste skriva ett nummer." << std::endl;
	}

	std::wcout << sqrtf(num) << std::endl;
	std::wcout << num * num << std::endl;
	std::wcout << powf(num, 10) << std::endl;
}

/**
* Function 10
* Print multiplication table 10
*/
void Tasks::Table()
{
	std::wstring table = L"";

	for (size_t i = 1; i < 11; i++) {
		for (size_t j = 1; j < 11; j++) {
			table += std::to_wstring(i * j) + L"\t";
		}
		table += L"\n";
	}

	std::wcout << table << std::endl;
}

/**
* Function 11
* Generate random array and sort it.
* Note: The spec said that two arrays (vectors) where to be used. Using the 
*	method below that would just have copy constructed another vector and 
*	sorted that by reference.
* Generate used instead of a loop.
* Lambda used instead of another helper function.
*/
void Tasks::Sort()
{
	const size_t size = 10;
	std::vector<int> array(size);

	std::generate(array.begin(), array.end(), [size]() { return std::rand() % (size * 10); });

	printVector(array);
	bubbleSort(array);
	printVector(array);
}

/**
* Bubblesort helper function
* Slow but dependable :)
*/
template<typename T>
void Tasks::bubbleSort(std::vector<T> &v)
{
	for (size_t i = 0; i < v.size() - 1; ++i) {
		for (size_t j = 0; j < v.size() - i - 1; ++j) {
			if (v.at(j) > v.at(j + 1))
				std::swap(v.at(j), v.at(j + 1));
		}
	}
}

/**
* Vector printing helper function
*/
template<typename T>
void Tasks::printVector(const std::vector<T> v)
{
	for (auto i = v.begin(); i < v.end(); i++) {
		std::wcout << std::to_wstring(*i);
		if (i != v.end() - 1)
			std::wcout << L", ";
	}
	std::wcout << std::endl;
}

/**
* Function 12
* Test if string is a palindrome
* Note: 
*	Could have used std::reverse here
*/
void Tasks::Palindrome()
{
	std::wstring buff = L"";
	bool palindrom = true;
	size_t len;

	std::wcout << L"Skriv in ett ord\n> ";
	std::wcin >> buff;
	len = buff.length();

	if (len > 0) {
		for (size_t i = 0; i < len / 2; i++) {
			if (buff[i] != buff[len - i - 1]) {
				palindrom = false;
				break;
			}
		}

		if (palindrom)
			std::wcout << L"Palindrom" << std::endl;
		else
			std::wcout << L"Inget palindrom" << std::endl;
	}
}

/**
* Function 13
* Print all numbers between input numbers
*/
void Tasks::Between()
{
	std::wstring buff1, buff2;
	int32_t a = 0, b = 0;

	std::wcout << L"Skriv in två nummer (mellanslags-separearade)\n> ";
	std::wcin >> buff1 >> buff2;

	try {
		a = std::stoi(buff1);
		b = std::stoi(buff2);
	}
	catch (...) {
		system("cls");
		std::wcout << L"Du måste skriva in två nummer!" << std::endl;
	}

	if (a < b) {
		for (int32_t i = a + 1; i < b; i++) {
			std::wcout << i << L" ";
		}
	}
	else {
		for (int32_t i = a - 1; i > b; i--) {
			std::wcout << i << L" ";
		}
	}

	std::wcout << std::endl;
}

/**
* Read comma separated values from input
* Helper function
*/
void Tasks::readCsvInput(std::vector<int>& v)
{
	std::wstring buff;
	std::wstring tmp;
	std::size_t dpos, dposp = 0;

	std::wcin.ignore();
	std::getline(std::wcin, buff);

	while ((dpos = buff.find(L",", dposp)) != std::wstring::npos) {
		tmp = buff.substr(dposp, dpos - dposp);
		dposp = dpos + 1;

		try {
			v.push_back(std::stoi(tmp));
		}
		catch (...) { }
	}

	try {
		v.push_back(std::stoi(buff.substr(dposp)));
	}
	catch (...) { }
}

/**
* Function 14
* Read in numbers and order them odd and even
*/
void Tasks::OddEven()
{
	std::vector<int32_t> numbers, odd, even;

	std::wcout << L"Skriv in nummer (komma-separerade)\n> ";
	readCsvInput(numbers);

	for (auto i : numbers)
		if (i % 2 == 0)
			even.push_back(i);
		else
			odd.push_back(i);

	std::wcout << L"Udda: ";
	printVector(odd);
	std::wcout << L"Jämna: ";
	printVector(even);
	std::wcout << std::endl;
}

/**
* Function 15
* Read in numbers and sum them
*/
void Tasks::Sum()
{
	std::vector<int32_t> numbers;
	int32_t sum = 0;

	std::wcout << "Skriv in nummer (komma-separerade)\n> ";
	readCsvInput(numbers);

	for (auto i : numbers)
		sum += i;

	std::wcout << L"Summa: " << sum << std::endl;
}

void Tasks::Game()
{
	std::wstring p1, p2;

	while (1) {
		std::wcout << "Vad heter spelare 1?\n> ";
		std::wcin >> p1;

		if (p1.length() < 1) {
			continue;
		}
		else
			break;
	}

	while (1) {
		std::wcout << "Vad heter spelare 2?\n> ";
		std::wcin >> p2;

		if (p2.length() < 1)
			continue;
		else
			break;
	}

	Character player1(p1);
	Character player2(p2);

	player1.print();
	player2.print();
}
