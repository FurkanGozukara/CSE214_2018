// Calculate_Power_Divide_and_Conquer.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdlib.h" 

int powerCallNumber = 0;

float power(float x, int y)
{
	powerCallNumber++;
	float temp;
	if (y == 0)
		return 1;
	temp = power(x, y / 2);
	printf("call number: %d , temp value: %f\n", powerCallNumber, temp);
	if (y % 2 == 0)
		return temp * temp;
	else
	{
		if (y > 0)
			return x * temp * temp;
		else
			return (temp * temp) / x;
	}
}

float power_regular(float x, int y)
{
	float temp = x;
	if (y < 0)
		temp = 1 / x;
	for (size_t i = 1; i < abs(y); i++)
	{
		powerCallNumber++;
		if (y > 0)
			temp = temp * x;
		else
			temp = temp * 1 / x;
	}

	printf("call number: %d , temp value: %f\n", powerCallNumber, temp);

	return temp;

}

/* Program to test function power */
int main()
{
	float x = 2;
	int y =13;
	printf("%f\n\n", power(x, y));
	powerCallNumber = 0;
	printf("%f\n\n", power_regular(x, y));
	char str[80];
	scanf_s("%79s", str);
	return 0;
}


