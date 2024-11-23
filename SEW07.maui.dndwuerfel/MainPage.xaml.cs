

namespace SEW07.maui.dndwuerfel
{
    public partial class MainPage : ContentPage
    {
        private Action<int[]> diceroller;
        private int currentdice = 20;

        private Dice di20;
        private Dice di10;
        private Dice di12;
        private Dice di100;
        private Dice di8;
        private Dice di6;
        private Dice di4;

        public MainPage()
        {
            InitializeComponent();

            // Initialize the delegate
            diceroller = new Action<int[]>(normaldiceroll);

            // Initialize Dice objects in the constructor
            di20 = new Dice("d20", "d20.png", 20, new int[] { 1, 20}, diceroller);
            di10 = new Dice("d10", "d10.png", 10, new int[] { 1, 10}, diceroller);
            di12 = new Dice("d12", "d12.png", 12, new int[] { 1, 12}, diceroller);
            di100 = new Dice("d100", "d100.png", 100, new int[] { 0, 10}, diceroller);
            di8 = new Dice("d8", "d8.png", 8, new int[] { 1, 8}, diceroller);
            di6 = new Dice("d6", "d6.png", 6, new int[] { 1, 6}, diceroller);
            di4 = new Dice("d4", "d4.png", 4, new int[] { 1, 4}, diceroller);
        }

        public void normaldiceroll(int[] range)
        {
            Random r = new Random();

            lbl.Text = r.Next(range[0], range[1]).ToString();
        }

        public void d100roll(int[] range)
        {
            Random r = new Random();

            int erg = r.Next(range[0], range[1])*10;
            lbl.Text = erg.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            imgwuerfel.RelRotateTo(0);

            switch (currentdice)
            {
                case 20:
                    di20.Diceroller = normaldiceroll;
                    di20.rolldice();
                    break;
                case 12:
                    di12.Diceroller = normaldiceroll;
                    di12.rolldice();
                    break;
                case 10:
                    di10.Diceroller = normaldiceroll;
                    di10.rolldice();
                    break;
                case 100:
                    di100.Diceroller = d100roll;
                    di100.rolldice();
                    break;
                case 8:
                    di8.Diceroller = normaldiceroll;
                    di8.rolldice();
                    break;
                case 6:
                    di6.Diceroller = normaldiceroll;
                    di6.rolldice();
                    break;
                case 4:
                    di4.Diceroller = normaldiceroll;
                    di4.rolldice();
                    break;
            }
            
            imgwuerfel.RotateTo(360);
            


        }

        private void D20_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(this.D20.IsChecked)
            {
                currentdice = di20.Index;
                imgwuerfel.Source = di20.Picturepath;
            }
        }

        private void D12_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (this.D12.IsChecked)
            {
                currentdice = di12.Index;
                imgwuerfel.Source = di12.Picturepath;
            }
        }

        private void D10_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (this.D10.IsChecked)
            {
                currentdice = di10.Index;
                imgwuerfel.Source = di10.Picturepath;
            }
        }

        private void D100_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (this.D100.IsChecked)
            {
                currentdice = di100.Index;
                imgwuerfel.Source = di100.Picturepath;
            }
        }

        private void D8_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (this.D8.IsChecked)
            {
                currentdice = di8.Index;
                imgwuerfel.Source = di8.Picturepath;
            }
        }

        private void D6_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (this.D6.IsChecked)
            {
                currentdice = di6.Index;
                imgwuerfel.Source = di6.Picturepath;
            }
        }

        private void D4_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (this.D4.IsChecked)
            {
                currentdice = di4.Index;
                imgwuerfel.Source = di4.Picturepath;
            }
        }
    }

    public class Dice
    {
        private string name;
        private string picturepath;
        private int index;
        private int[] dicerange; //max,min,step
        private Action<int[]> diceroller;

        public Dice(string name, string picturepath, int index, int[] dicerange, Action<int[]> diceroller)
        {
            this.Name = name;
            this.Picturepath = picturepath;
            this.Index = index;
            this.dicerange = dicerange;
            this.diceroller = diceroller;
        }

        public string Name { get => name; set => name = value; }
        public string Picturepath { get => picturepath; set => picturepath = value; }
        public int Index { get => index; set => index = value; }
        public int[] Dicerange { get => dicerange; set => dicerange = value; }
        public Action<int[]> Diceroller { get => diceroller; set => diceroller = value; }

        public void rolldice()
        {
            diceroller(dicerange);
        }

    }

}
