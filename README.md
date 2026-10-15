# Tool Rental Discount — Practice

Build a small Windows Forms application for a tool rental shop. The customer rents **one tool** for a number of days. The shop charges a daily price and gives a **10% discount on the entire rental charge** when the rental lasts at least a specified number of days.

For example, if the discount starts at 3 days, a customer renting for 3 days qualifies. A customer renting for 2 days does not.

This is an independent practice exercise, not an instructor assignment or a prediction of the real quiz. It is not handed in. Try it in **50 minutes**, then use the tests to check your work. You can repeat it with a fresh clone.

## Open the starter

You need **Visual Studio 2026**, the **.NET desktop development** workload, and the **.NET 10 SDK**.

1. Clone this repository in Visual Studio.
2. Open **ToolRentalPractice.sln**.
3. Set **ToolRentalPractice** as the startup project if necessary.
4. Open **Form1** in the Windows Forms Designer.

The starter builds and opens a form. Its picture is already supplied. The calculation has not been implemented.

## Naming and saving

Use every name below **exactly**, including capital letters. These names use a type prefix followed by camelCase words, such as `decDailyRate` and `txtTotalCharge`.

Make at least one Git commit for each section: **fields**, **controls**, **calculation/output**, and **error handling**. Make more commits if they help you keep track of your work.

## 1. Create four fields [4 marks]

Declare these fields in the form class, outside its methods and event handlers.

| Field name | C# type | Meaning |
| --- | --- | --- |
| `intDays` | `int` | Number of days the customer rents the tool |
| `decDailyRate` | `decimal` | Rental price for one day |
| `intDiscountDays` | `int` | Number of days needed to qualify for the discount |
| `decTotalCharge` | `decimal` | Final amount the customer pays |

## 2. Create and name the controls [8 marks]

| Control name | Type | Purpose |
| --- | --- | --- |
| `txtDays` | TextBox | Customer enters the rental days |
| `txtDailyRate` | TextBox | Customer enters the price per day |
| `txtDiscountDays` | TextBox | Customer enters the days needed for the discount |
| `txtTotalCharge` | TextBox | Displays the final amount |
| `btnCalculate` | Button | Calculates the amount |
| `picTool` | PictureBox | Displays the supplied tool picture |
| `lblNote` | Label | Displays which rate was applied |
| `lblError` | Label | Displays an input error |

Set the **Enabled** property of `txtTotalCharge` to **False**. The customer must not be able to type into the result box.

The supplied PictureBox is currently named `pictureBox1`. Rename that **control** to `picTool`. You do not need to replace, animate, or program the picture.

Add readable labels beside the textboxes so the user knows what to enter. These extra labels can keep their default names and are not worth marks. Choose your own sensible layout and button text.

## 3. Calculate and display the rental charge [8 marks]

When `btnCalculate` is clicked, the application must do the following:

- Read rental days from `txtDays` into `intDays`.
- Read the daily price from `txtDailyRate` into `decDailyRate`.
- Read the discount threshold from `txtDiscountDays` into `intDiscountDays`.
- Calculate the rental charge: **rental days × daily price**.
- If the rental days are **greater than or equal to** the discount threshold, reduce the entire charge by **10%**. Set `lblNote` to exactly **`Long rental discount`**.
- Otherwise, use the full rental charge. Set `lblNote` to exactly **`Standard rate`**.
- Store the final amount in `decTotalCharge` and display it in `txtTotalCharge` using **`.ToString("C")`**.

The discount applies to the **whole rental**, not just the days above the threshold. There is one rental charge and no tax or deposit.

The final amount displayed is worth **4 marks**. The correct note is worth **4 marks**.

## 4. Handle invalid input [3 marks]

- `txtDays` and `txtDiscountDays` accept **whole numbers only**. A value such as `2.5` is not valid in either box.
- `txtDailyRate` accepts decimal amounts, such as `49.50`.
- If any input is not a valid number for its required type, handle the error without crashing. Display exactly **`Please enter valid numbers`** in `lblError`.

For example, `2.0A` is invalid. Check each of the three input boxes separately. Error handling for each input box is worth **1 mark**.

Assume otherwise valid inputs are positive and within the range of their types. Additional rules for zero or negative values are not required. No marks depend on clearing an earlier error message.

## Check your results

| Rental days | Daily price | Discount starts at | Final charge | Exact note |
| --- | --- | --- | --- | --- |
| 2 | 50 | 3 days | $100.00 | `Standard rate` |
| 3 | 50 | 3 days | $135.00 | `Long rental discount` |
| 5 | 40 | 3 days | $180.00 | `Long rental discount` |

The currency symbol and separators follow your computer's current culture, as produced by the `"C"` format.

## Run the automated checks

1. Save your work and stop the application if it is running.
2. Choose **Build → Build Solution**.
3. Choose **Test → Test Explorer**.
4. In Test Explorer, choose **Run All Tests**.

`TestProject1` contains **23 tests, one test per mark**. Read any failed test's message to see which requirement needs attention. Failing tests are expected in the untouched starter because you have not completed the exercise yet.

## Mark breakdown

| Section | Marks |
| --- | ---: |
| Four fields | 4 |
| Eight controls | 8 |
| Final amount in `txtTotalCharge` | 4 |
| Text in `lblNote` | 4 |
| Error handling | 3 |
| **Total** | **23** |

Before calling the practice complete, explain what each field holds, when the discount applies, and how your application handles bad input.

## Reference material

This is a newly written exercise. Its beginner scope was checked against Microsoft's [C# decision-logic exercises](https://learn.microsoft.com/en-us/training/modules/csharp-if-elseif-else/) and [Windows Forms introduction](https://learn.microsoft.com/en-us/visualstudio/ide/create-csharp-winform-visual-studio?view=visualstudio). Those pages are references, not this exercise's specification. The exact requirements and practice marks are all listed above.
