namespace Lab01_Client
{
    public partial class Lab01 : Form
    {
        public Lab01()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var x = textBox1.Text;
            var y = textBox2.Text;

            HttpClient client = new HttpClient();
            var res = await client.PostAsync($"http://localhost:5023/4?x={x}&y={y}", null);
            textBox3.Text = await res.Content.ReadAsStringAsync();
        }
    }
}
