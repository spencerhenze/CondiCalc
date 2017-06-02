using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CondiCalc_XFP
{
    public class ConditioningCalcPage : ContentPage
    {
        Label topLabel = new Label
        {
            Text = "Enter Gymnast's Scores",
            HorizontalOptions = LayoutOptions.Center,
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            FontAttributes = FontAttributes.Bold
        };

        //Begin entry cells here:
        public static EntryCell pressHSEntryCell = new EntryCell
        {
            Label = "Press Handstand: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell legLiftsEntryCell = new EntryCell
        {
            Label = "Leg Lifts: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell castHSEntryCell = new EntryCell
        {
            Label = "Cast Handstand: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell blockJumpsEntryCell = new EntryCell
        {
            Label = "Block Jumps: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell archUpsEntryCell = new EntryCell
        {
            Label = "Arch-Ups (5-lb): ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell splitsTotalEntryCell = new EntryCell
        {
            Label = "Splits Total: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell hsHoldEntryCell = new EntryCell
        {
            Label = "Handstand Hold: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell horizLegLiftsEntryCell = new EntryCell
        {
            Label = "Horizontal Leg Lifts: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell ropeEntryCell = new EntryCell
        {
            Label = "Rope: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell leversEntryCell = new EntryCell
        {
            Label = "Levers: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };

        public static EntryCell lungeJumpsEntryCell = new EntryCell
        {
            Label = "Lunge Jumps: ",
            Keyboard = Keyboard.Numeric,
            Text = ""
        };


        //Declare buttons

        public static Button clearButton = new Button()
        {
            Text = "Clear",
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Margin = new Thickness(20, 0, 0, 0)

        };

        public static Button calculateButton = new Button
        {
            Text = "Calculate",
            HorizontalOptions = LayoutOptions.EndAndExpand,
            Margin = new Thickness(0, 0, 20, 0)
        };


        //TableView objects can be added to a stacklayout. Put (nest) EntryCell objects into it, then add it to the stacklayout.

        TableView entryTable = new TableView
        {
            HeightRequest = 1200,
            VerticalOptions = LayoutOptions.Start,
            Intent = TableIntent.Form,
            Root = new TableRoot
            {
                new TableSection
                {
                    pressHSEntryCell,
                    hsHoldEntryCell,
                    legLiftsEntryCell,
                    horizLegLiftsEntryCell,
                    castHSEntryCell,
                    ropeEntryCell,
                    blockJumpsEntryCell,
                    leversEntryCell,
                    archUpsEntryCell,
                    lungeJumpsEntryCell,
                    splitsTotalEntryCell
                }// End new TableSection
            }// End new TableRoot
        };//End new TableView



        // Declare the horizontal stacklayout for the buttons:

        StackLayout horizStack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(0, 0, 0, 30),

            Children = {
                clearButton,
                calculateButton
            }
        };


        //Declare functional methods

        void ClearButtonClicked(object sender, EventArgs e)
        {
            pressHSEntryCell.Text = "";
            hsHoldEntryCell.Text = "";
            legLiftsEntryCell.Text = "";
            horizLegLiftsEntryCell.Text = "";
            castHSEntryCell.Text = "";
            ropeEntryCell.Text = "";
            blockJumpsEntryCell.Text = "";
            leversEntryCell.Text = "";
            archUpsEntryCell.Text = "";
            lungeJumpsEntryCell.Text = "";
            splitsTotalEntryCell.Text = "";
        }

        void CalculateButtonClicked(object sender, EventArgs e)
        {
            double finalScore = 0.0;
            const double pointsPossible = 1100;

            try
            {
                //Create new exercise objects out of the individual classes of type Exercise
                PressHS myPressHS = new PressHS(Convert.ToDouble(pressHSEntryCell.Text));
                HSHold myHSHold = new HSHold(Convert.ToDouble(hsHoldEntryCell.Text));
                LegLifts myLegLifts = new LegLifts(Convert.ToDouble(horizLegLiftsEntryCell.Text));
                HorizLegLifts myHorizLegLifts = new HorizLegLifts(Convert.ToDouble(horizLegLiftsEntryCell.Text));
                CastHS myCastHS = new CastHS(Convert.ToDouble(castHSEntryCell.Text));
                Rope myRope = new Rope(Convert.ToDouble(ropeEntryCell.Text));
                BlockJumps myBlockJumps = new BlockJumps(Convert.ToDouble(blockJumpsEntryCell.Text));
                Levers myLevers = new Levers(Convert.ToDouble(leversEntryCell.Text));
                ArchUps myArchUps = new ArchUps(Convert.ToDouble(archUpsEntryCell.Text));
                LungeJumps myLungeJumps = new LungeJumps(Convert.ToDouble(lungeJumpsEntryCell.Text));
                Splits mySplits = new Splits(Convert.ToDouble(splitsTotalEntryCell.Text));

                //Define the finalScore value by adding together the Percentage properties (which are automatically calculated in their respective classes) of each exercise object.
                finalScore = ((myPressHS.Percentage + myHSHold.Percentage + myLegLifts.Percentage + myHorizLegLifts.Percentage + myCastHS.Percentage + myRope.Percentage + myBlockJumps.Percentage + myLevers.Percentage + myArchUps.Percentage + myLungeJumps.Percentage + mySplits.Percentage) / pointsPossible) * 100;

                //Display the score in a popup message.
                string scoreStatement = String.Format("The gymnast's overall score is {0:0.00} %", finalScore);
                DisplayAlert("Overall Score", scoreStatement , "OK");
            }

            catch (FormatException)
            {
                DisplayAlert("Error", "Oops! Make sure you only enter numbers in the fields and that there are no blank fields.", "OK");
            }
            catch (Exception)
            {
                DisplayAlert("Error", "Oops! Something went wrong. Check your entries and try again.", "OK");
            }

        }


        //Begin constructor 
        public ConditioningCalcPage()
        {
            Title = "Conditioning Calculator";

            //Connect button actions to methods here:
            clearButton.Clicked += ClearButtonClicked;
            calculateButton.Clicked += CalculateButtonClicked;

            //Build the main stacklayout
            Content = new StackLayout
            {
                Children = {
                    topLabel,
                    entryTable,
                    horizStack
                }
            };
        } // End Constructor
    }
}
