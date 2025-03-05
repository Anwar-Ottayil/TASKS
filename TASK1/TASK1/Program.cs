// See https://aka.ms/new-console-template for more information


// Question 1  check if a number is odd or even

// Answer
int num = 10;
string r = (num % 2 == 0) ? "the given number is Even" : "the given number is odd";
Console.WriteLine(r);


// Question 2. Check if a number is Positive, Negative, or Zero.


// Answer
int a = 0;
string result = (a > 0) ? "The number is Positive" :
               (a < 0) ? "The number is Negative " : "The number is Zero";
Console.WriteLine(result);

// 3.Find the largest of three numbers.
int first = 60;
int second = 20;
int third = 30;
int largest =(first > second)
                      ? ((first > third) ? first : third)
                      : ((second > third) ? second : third);
Console.WriteLine($"The largest number is: {largest}");

// 4.Find if a year is a leap year or not.
//1. If the year is divisible by 4 and not divisible by 100 then print “leap year”.
//2. Or if the year is divisible by 400 then print “leap year”.
//3. Else print “not a leap year”.
int year = 2023;
string resu = (year % 4 == 0&& year%100!=0)|| (year % 400 == 0)
            ? "leap year" :
            "Not leap year";
Console.WriteLine(resu);

// 5.Find the grade for input marks.
//1. Print “S grade” if the mark is between 90 and 100.
//2. Print “A grade” if the mark is between 80 and 90.
//3. Print “B grade” if the mark is between 70 and 80.
//4. Print “C grade” if the mark is between 60 and 70.
//5. Print “D grade” if the mark is between 50 and 60.
//6. Print “E grade” if the mark is between 40 and 50.
//7. Print “Student has failed” if the mark is between 0 and 40.
//8. Else print “Invalid marks

int mark = 101;
string grade = (mark > 100)||(mark<1) ? "invalid" :
             (mark >= 90) ? "S grade" :
             (mark >= 80) ? "A grade" :
             (mark >= 70) ? "B grade" :
             (mark >= 60) ? "C grade" :
             (mark >= 50) ? "D grade" :
             (mark >= 40) ? "E grade" :
             "student has failed";
Console.WriteLine(grade);
