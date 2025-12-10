using ClosedXML;
using ClosedXML.Excel;
using softeng_zh_form.PcShopModels;

namespace softeng_zh_form
{
    public partial class Form1 : Form
    {
        PcShopContext context;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context = new();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Biztos?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            OrderControl uc = new();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context = new();

            {
                var orders = (from x in context.Components
                              select new
                              {
                                  Category = x.Category.Name,
                                  x.Name,
                                  x.Brand,
                                  x.Price,
                              }).ToList();


                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Components");

                worksheet.Cell(1, 1).InsertTable(orders);

                SaveFileDialog sfd = new();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                }


            }
        }
    }
}
