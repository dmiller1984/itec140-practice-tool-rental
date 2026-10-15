using System.Globalization;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolRentalPractice;

[assembly: DoNotParallelize]

namespace TestProject1;

// Each test is worth one practice mark. The unfinished starter is expected to fail.
// Reflection lets these tests build before the required fields and controls exist.
[TestClass]
public class PracticeMarkTests
{
    [TestMethod]
    [TestCategory("Fields")]
    public void Mark01_IntDays_IsAnIntField() => AssertField("intDays", typeof(int));

    [TestMethod]
    [TestCategory("Fields")]
    public void Mark02_DecDailyRate_IsADecimalField() => AssertField("decDailyRate", typeof(decimal));

    [TestMethod]
    [TestCategory("Fields")]
    public void Mark03_IntDiscountDays_IsAnIntField() => AssertField("intDiscountDays", typeof(int));

    [TestMethod]
    [TestCategory("Fields")]
    public void Mark04_DecTotalCharge_IsADecimalField() => AssertField("decTotalCharge", typeof(decimal));

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark05_TxtDays_IsATextBox() => AssertControl<TextBox>("txtDays");

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark06_TxtDailyRate_IsATextBox() => AssertControl<TextBox>("txtDailyRate");

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark07_TxtDiscountDays_IsATextBox() => AssertControl<TextBox>("txtDiscountDays");

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark08_TxtTotalCharge_IsADisabledTextBox()
    {
        OnForm(form =>
        {
            TextBox output = RequiredControl<TextBox>(form, "txtTotalCharge");
            Assert.IsFalse(output.Enabled, "Set txtTotalCharge.Enabled to False in the Designer.");
        });
    }

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark09_BtnCalculate_IsAButton() => AssertControl<Button>("btnCalculate");

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark10_PicTool_IsAPictureBox() => AssertControl<PictureBox>("picTool");

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark11_LblNote_IsALabel() => AssertControl<Label>("lblNote");

    [TestMethod]
    [TestCategory("Controls")]
    public void Mark12_LblError_IsALabel() => AssertControl<Label>("lblError");

    [TestMethod]
    [TestCategory("Charge output")]
    public void Mark13_BelowDiscountThreshold_DisplaysFullCharge()
    {
        OnForm(form =>
        {
            Calculate(form, "2", "30", "5");
            AssertCharge(form, 60m, "$60.00");
        });
    }

    [TestMethod]
    [TestCategory("Charge output")]
    public void Mark14_ExactlyAtDiscountThreshold_DisplaysDiscountedCharge()
    {
        OnForm(form =>
        {
            Calculate(form, "5", "30", "5");
            AssertCharge(form, 135m, "$135.00");
        });
    }

    [TestMethod]
    [TestCategory("Charge output")]
    public void Mark15_AboveDiscountThreshold_DisplaysFinalChargeAfterDecision()
    {
        OnForm(form =>
        {
            Calculate(form, "8", "30", "5");
            AssertCharge(form, 216m, "$216.00");
        });
    }

    [TestMethod]
    [TestCategory("Charge output")]
    public void Mark16_FractionalDailyRate_DisplaysCurrencyWithTwoDecimalPlaces()
    {
        OnForm(form =>
        {
            Calculate(form, "6", "19.95", "5");
            AssertCharge(form, 107.73m, "$107.73");
        });
    }

    [TestMethod]
    [TestCategory("Note output")]
    public void Mark17_BelowDiscountThreshold_ShowsStandardRate()
    {
        OnForm(form =>
        {
            Calculate(form, "2", "30", "5");
            AssertNote(form, "Standard rate");
        });
    }

    [TestMethod]
    [TestCategory("Note output")]
    public void Mark18_ExactlyAtDiscountThreshold_ShowsLongRentalDiscount()
    {
        OnForm(form =>
        {
            Calculate(form, "5", "30", "5");
            AssertNote(form, "Long rental discount");
        });
    }

    [TestMethod]
    [TestCategory("Note output")]
    public void Mark19_AboveDiscountThreshold_ShowsLongRentalDiscount()
    {
        OnForm(form =>
        {
            Calculate(form, "8", "30", "5");
            AssertNote(form, "Long rental discount");
        });
    }

    [TestMethod]
    [TestCategory("Note output")]
    public void Mark20_CalculatingAgain_UpdatesTheNoteForTheNewInputs()
    {
        OnForm(form =>
        {
            Calculate(form, "8", "30", "5");
            AssertNote(form, "Long rental discount");
            Calculate(form, "2", "30", "5");
            AssertNote(form, "Standard rate");
        });
    }

    [TestMethod]
    [TestCategory("Error handling")]
    public void Mark21_InvalidDays_ShowsTheExactErrorMessage()
        => AssertInvalidInput("2.0A", "30", "5");

    [TestMethod]
    [TestCategory("Error handling")]
    public void Mark22_InvalidDailyRate_ShowsTheExactErrorMessage()
        => AssertInvalidInput("2", "2.0A", "5");

    [TestMethod]
    [TestCategory("Error handling")]
    public void Mark23_InvalidDiscountDays_ShowsTheExactErrorMessage()
        => AssertInvalidInput("2", "30", "2.0A");

    private static void AssertField(string name, Type expectedType)
    {
        FieldInfo? field = typeof(Form1).GetField(name,
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        Assert.IsNotNull(field,
            $"Declare {name} inside the Form1 class and outside every method. Use the exact spelling.");
        Assert.AreEqual(expectedType, field!.FieldType, $"{name} must have type {expectedType.Name}.");
    }

    private static void AssertControl<T>(string name) where T : Control
        => OnForm(form => { _ = RequiredControl<T>(form, name); });

    private static T RequiredControl<T>(Form form, string name) where T : Control
    {
        List<Control> matches = Descendants(form).Where(control => control.Name == name).ToList();
        Assert.AreEqual(1, matches.Count,
            $"Expected exactly one control named {name}. Check its (Name) property, including capitals.");
        Assert.IsInstanceOfType(matches[0], typeof(T), $"{name} must be a {typeof(T).Name}.");
        return (T)matches[0];
    }

    private static IEnumerable<Control> Descendants(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            yield return child;
            foreach (Control descendant in Descendants(child))
            {
                yield return descendant;
            }
        }
    }

    private static void Calculate(Form form, string days, string dailyRate, string discountDays)
    {
        RequiredControl<TextBox>(form, "txtDays").Text = days;
        RequiredControl<TextBox>(form, "txtDailyRate").Text = dailyRate;
        RequiredControl<TextBox>(form, "txtDiscountDays").Text = discountDays;
        Button button = RequiredControl<Button>(form, "btnCalculate");
        Assert.IsTrue(button.Enabled && button.Visible, "btnCalculate must be enabled and visible.");
        button.PerformClick();
    }

    private static void AssertCharge(Form form, decimal expectedValue, string expectedDisplay)
    {
        FieldInfo? field = typeof(Form1).GetField("decTotalCharge",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        Assert.IsNotNull(field, "Declare decTotalCharge as a decimal field on Form1.");
        Assert.AreEqual(typeof(decimal), field!.FieldType, "decTotalCharge must be a decimal field.");
        Assert.AreEqual(expectedValue, (decimal)field.GetValue(form)!,
            "decTotalCharge must contain the final amount after the discount decision.");
        Assert.AreEqual(expectedDisplay, RequiredControl<TextBox>(form, "txtTotalCharge").Text,
            "Display the final charge with currency formatting after making the discount decision.");
    }

    private static void AssertNote(Form form, string expectedText)
        => Assert.AreEqual(expectedText, RequiredControl<Label>(form, "lblNote").Text,
            "lblNote must contain the exact text in the README, with no extra punctuation or spaces.");

    private static void AssertInvalidInput(string days, string dailyRate, string discountDays)
    {
        OnForm(form =>
        {
            Calculate(form, days, dailyRate, discountDays);
            Assert.AreEqual("Please enter valid numbers", RequiredControl<Label>(form, "lblError").Text,
                "Handle bad input and put the exact required message in lblError.");
        });
    }

    private static void OnForm(Action<Form1> check)
    {
        Exception? failure = null;
        Thread uiThread = new(() =>
        {
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-CA");
                CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-CA");
                using Form1 form = new();
                form.ShowInTaskbar = false;
                form.Show();
                Application.DoEvents();
                check(form);
            }
            catch (Exception exception)
            {
                failure = exception;
            }
        })
        {
            IsBackground = true
        };

        uiThread.SetApartmentState(ApartmentState.STA);
        uiThread.Start();
        Assert.IsTrue(uiThread.Join(TimeSpan.FromSeconds(15)),
            "The form did not finish this check within 15 seconds. Close any modal dialog and check the button code.");
        if (failure is not null)
        {
            ExceptionDispatchInfo.Capture(failure).Throw();
        }
    }
}
