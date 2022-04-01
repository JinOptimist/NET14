//create function to get the sum of all the numbers in the array
int [] nums = {1,2,3,4,5,6,7,8,9,10};
int sum = 0;
for(int i = 0; i < nums.Length; i++)
{
    sum += nums[i];
}
Console.WriteLine(sum);

//create function to create an array all days of month
string [] daysOfMonth = new string[31];
for(int i = 0; i < daysOfMonth.Length; i++)
{
    daysOfMonth[i] = (i + 1).ToString();
}
Console.WriteLine(daysOfMonth[0]);

