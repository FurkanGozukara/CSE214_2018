// A Divide and Conquer based program for maximum subarray sum problem
#include "stdio.h"
#include "stdafx.h"
#include "limits.h"
#include "vector"

// A utility funtion to find maximum of two integers
int max(int a, int b) { return (a > b) ? a : b; }

// A utility funtion to find maximum of three integers
int max(int a, int b, int c) { return max(max(a, b), c); }

int maxCrossCallCount = 0;
// Find the maximum possible sum in arr[] auch that arr[m] is part of it
int maxCrossingSum(int arr[], int l, int m, int h)
{
	maxCrossCallCount++;
	printf("max cross sum call: %d\n", maxCrossCallCount);
	for (int i = l; i <= h; ++i)
		printf("%d ; ", arr[i]);
	printf("\n");

	// Include elements on left of mid.
	int sum = 0;
	int left_sum = INT_MIN;
	for (int i = m; i >= l; i--)
	{
		sum = sum + arr[i];
		if (sum > left_sum)
			left_sum = sum;
	}

	// Include elements on right of mid
	sum = 0;
	int right_sum = INT_MIN;
	for (int i = m + 1; i <= h; i++)
	{
		sum = sum + arr[i];
		if (sum > right_sum)
			right_sum = sum;
	}

	// Return sum of elements on left and right of mid
	printf("max left sum %d, max right sum %d, sum of both %d\n", left_sum, right_sum, (left_sum + right_sum));
	return left_sum + right_sum;
}

int maxSubArray = 0;

// Returns sum of maxium sum subarray in aa[l..h]
int maxSubArraySum(int arr[], int l, int h)
{
	maxSubArray++;
	printf("max sub array call: %d\n", maxSubArray);
	for (int i = l; i <= h; ++i)
		printf("%d ; ", arr[i]);
	printf("\n");

	// Base Case: Only one element
	if (l == h)
		return arr[l];

	// Find middle point
	int m = (l + h) / 2;

	/* Return maximum of following three possible cases
	a) Maximum subarray sum in left half
	b) Maximum subarray sum in right half
	c) Maximum subarray sum such that the subarray crosses the midpoint */
	// Return sum of elements on left and right of mid
	int maxSub = max(maxSubArraySum(arr, l, m),
		maxSubArraySum(arr, m + 1, h),
		maxCrossingSum(arr, l, m, h));
	printf("Maximum subarray: %d\n", maxSub);
	return  maxSub;
}



int irNaiveLoopCount = 0;

void naiveFinding(int arr[], int n)
{
	int absMax = -2000000000;

	for (size_t i = 0; i < n; i++)
	{
		int thisLoopMax = arr[i];
		int thisTempMax = arr[i];

		for (size_t k = i + 1; k < n; k++)
		{
			thisTempMax += arr[k];
			if (thisTempMax > thisLoopMax)
			{
				thisLoopMax = thisTempMax;
			}
			irNaiveLoopCount++;
		}

		if (thisLoopMax > absMax)
			absMax = thisLoopMax;
	}
	printf("naive solution loop count %d\n", irNaiveLoopCount);
	printf("naive solution result %d\n", absMax);

}

/*Driver program to test maxSubArraySum*/
int main()
{
	int arr[] = { -3,5,11,2,15,-25,4,-44,7,13 };
	int n = sizeof(arr) / sizeof(arr[0]);
	int max_sum = maxSubArraySum(arr, 0, n - 1);
	printf("Maximum contiguous sum is %d\n", max_sum);
	naiveFinding(arr, n);

	getchar();
	return 0;
}