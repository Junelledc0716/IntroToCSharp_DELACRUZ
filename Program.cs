/*
=========================================================
 Program Title : Activity 1: Codac Logistics Fuel Monitoring System
 Author        : Junelle F. Dela Cruz
 Course        : BSIT 3.2
 Date          : 15-Feb-2026
=========================================================

PROGRAM OVERVIEW:
This console-based system monitors a single delivery vehicle's
fuel expenses and performance over a 5-day work week.

The system performs the following:

1. Collects driver information
2. Validates weekly budget and distance input
3. Stores daily fuel expenses using a 1D array
4. Calculates:
      - Total fuel spent
      - Average daily fuel expense
      - Fuel efficiency (km per PHP)
5. Evaluates efficiency using conditional statements
6. Determines if the driver stayed within budget
7. Generates a professional audit report

C# Concepts Used:
- string, decimal, double, bool
- Console input/output
- while loop (validation)
- for loop (array processing)
- if/else (efficiency rating)
- 1D array (fuel tracking)
*/

using System;

class Program
{
    static void Main()
    {
        // ==================================================
        // HEADER SECTION (Pastel Blue-Green)
        // ==================================================
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("============================================");
        Console.WriteLine("      CODAC LOGISTICS FUEL SYSTEM");
        Console.WriteLine("============================================");
        Console.ResetColor();
        Console.WriteLine();


        // ==================================================
        // DRIVER PROFILE & DISTANCE VALIDATION
        // ==================================================
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Driver Profile & Distance Validation ---\n");
        Console.ResetColor();
        Console.WriteLine();

        // STRING data type is used for textual information like names.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Enter Driver's Full Name: ");
        Console.ResetColor();
        string driverName = Console.ReadLine();


        // DECIMAL is used for money values because it avoids rounding errors.
        decimal weeklyBudget;

        // while loop ensures user cannot proceed unless input is valid.
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("    Enter Weekly Fuel Budget (PHP): ");
            Console.ResetColor();

            // TryParse prevents program crash if user types letters.
            if (decimal.TryParse(Console.ReadLine(), out weeklyBudget)
                && weeklyBudget > 0)
            {
                break; // exit loop if valid
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    Invalid input! Budget must be a positive number.");
            Console.ResetColor();
        }


        // DOUBLE is used for distance since kilometers may include decimals.
        double totalDistance;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("    Enter Total Distance Traveled This Week (1.0 - 5000.0 km): ");
            Console.ResetColor();

            if (double.TryParse(Console.ReadLine(), out totalDistance)
                && totalDistance >= 1.0 && totalDistance <= 5000.0)
            {
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    Invalid input! Distance must be between 1.0 and 5000.0 km.");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n    Driver profile recorded successfully!\n");
        Console.ResetColor();


        // ==================================================
        // FUEL EXPENSE TRACKING
        // ==================================================
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Fuel Expense Tracking ---\n");
        Console.ResetColor();
        Console.WriteLine();

        // 1D ARRAY stores 5 days of fuel expenses.
        decimal[] fuelExpenses = new decimal[5];

        // Accumulator variable for computing total fuel spent.
        decimal totalFuelSpent = 0m;

        // FOR LOOP runs exactly 5 times (Day 1 to Day 5).
        for (int day = 0; day < 5; day++)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"    Enter Fuel Cost for Day {day + 1} (PHP): ");
                Console.ResetColor();

                if (decimal.TryParse(Console.ReadLine(), out fuelExpenses[day])
                    && fuelExpenses[day] >= 0)
                {
                    // Add each valid entry to total.
                    totalFuelSpent += fuelExpenses[day];
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    Invalid input! Fuel cost must be zero or positive.");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n    Fuel expenses recorded successfully!\n");
        Console.ResetColor();


        // ==================================================
        // PERFORMANCE ANALYSIS
        // ==================================================
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Performance Analysis ---\n");
        Console.ResetColor();
        Console.WriteLine();

        // Compute average fuel expense.
        decimal averageFuelExpense = totalFuelSpent / 5;

        // Fuel efficiency formula:
        // Total Distance ÷ Total Fuel Spent
        double fuelEfficiency = totalDistance / (double)totalFuelSpent;

        // IF-ELSE logic to categorize efficiency.
        string efficiencyRating;

        if (fuelEfficiency > 15)
            efficiencyRating = "High Efficiency";
        else if (fuelEfficiency >= 10)
            efficiencyRating = "Standard Efficiency";
        else
            efficiencyRating = "Low Efficiency / Maintenance Required";

        // BOOLEAN value returns true if under budget.
        bool underBudget = totalFuelSpent <= weeklyBudget;

        // Display calculated results.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Average Daily Fuel Expense: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{averageFuelExpense:C}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Fuel Efficiency (km per PHP spent): ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{fuelEfficiency:F2}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Efficiency Rating: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(efficiencyRating);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Within Weekly Budget? ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(underBudget);
        Console.ResetColor();
        Console.WriteLine();


        // ==================================================
        // AUDIT REPORT
        // ==================================================
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Audit Report ---\n");
        Console.ResetColor();
        Console.WriteLine("========================================");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Driver Name: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(driverName);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Weekly Fuel Budget: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{weeklyBudget:C}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Total Distance Traveled: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{totalDistance:F2} km\n");

        Console.WriteLine("    Fuel Expenses Breakdown (5 days):");

        // Loop displays each day's expense from the array.
        for (int day = 0; day < 5; day++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"    Day {day + 1}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{fuelExpenses[day]:C}");
        }

        Console.WriteLine("========================================");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Total Fuel Spent: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{totalFuelSpent:C}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Average Daily Fuel Expense: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{averageFuelExpense:C}");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Fuel Efficiency Rating: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(efficiencyRating);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("    Within Weekly Budget? ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(underBudget);

        Console.WriteLine("========================================");

        Console.WriteLine("\n    Press any key to exit...");
        Console.ReadKey();
    }
}
