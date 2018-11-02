using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace restuarant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            rtb1.Document.Blocks.Clear();
            rtb.Document.Blocks.Clear();




            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();



        }

        void timer_Tick(object sender, EventArgs e)
        {
            time.Content = DateTime.Now.ToLongTimeString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // for attaching items in datagrid view

                FlowDocument myFlowDoc = new FlowDocument();

                // Add paragraphs to the FlowDocument

                myFlowDoc.Blocks.Add(new Paragraph(new Run("----------------Name----------------")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i11.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("----------------Units------------------")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i22.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("----------------Per Unit--------------")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i33.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("***************Total******************")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i44.Text)));

                rtb1.Document = myFlowDoc;
            }
            catch
            {
                MessageBox.Show("Some thing went wrong  in items Entry of Cosstumer");

            }

        }

        private void newb_Click(object sender, RoutedEventArgs e)
        {
             i22.Text = i33.Text = i44.Text = "";
        }

        Double plus = 0;

        private void totb_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Double units = Convert.ToDouble(i22.Text);
                Double perunit = Convert.ToDouble(i33.Text);
                Double f = units * perunit;

                plus = plus + f;

                i44.Text = Convert.ToString(plus);

            }
            catch
            {
                MessageBox.Show(" Enter item-units and per-unit-price of item then press Total Button  ");
            }
        }

        private void doneb_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                FlowDocument myFlowDoc = new FlowDocument();

                // Add paragraphs to the FlowDocument.
                myFlowDoc.Blocks.Add(new Paragraph(new Run("Customer Name : "+c11.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("Customer Mobile : " + c22.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("Table No :" + c33.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("Guests : " +c44.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("Visit Date : " + c55.Text)));

                myFlowDoc.Blocks.Add(new Paragraph(new Run("---------------- Item Names ----------------")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i11.Text)));
           /*     myFlowDoc.Blocks.Add(new Paragraph(new Run("----------------Units------------------")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i22.Text)));
                myFlowDoc.Blocks.Add(new Paragraph(new Run("----------------Per Unit--------------")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i33.Text)));     */
                myFlowDoc.Blocks.Add(new Paragraph(new Run("***************Total******************")));
                myFlowDoc.Blocks.Add(new Paragraph(new Run(i44.Text)));

                rtb.Document = myFlowDoc;




            }
            catch
            {
                MessageBox.Show("Some thing went wrong previously in Record Entry of Cosstumer");
            }
        }



        private void printb1_Click(object sender, RoutedEventArgs e)
        {
              
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                //use either one of the below     
                pd.PrintVisual(rtb as Visual, "Print Visual");
                pd.PrintDocument((((IDocumentPaginatorSource)rtb.Document).DocumentPaginator),
                    "Print Document");
            }

        }

        private void saveb123_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                string path = @""+pathtb.Text+""+c22.Text+".txt";

                if (!File.Exists(path))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(path))
                    {

                        string text2write = " Name : " + c11.Text + System.Environment.NewLine +
                                                  " Mobile : " + c22.Text + System.Environment.NewLine +
                                                  "Table No : " + c33.Text + System.Environment.NewLine +
                                                  "Guests : " + c44.Text + System.Environment.NewLine +
                                                  "Visit Date : " + c55.Text + System.Environment.NewLine + System.Environment.NewLine


                                        + " ************* Item Name *************" + System.Environment.NewLine +
                                       System.Environment.NewLine + i11.Text + System.Environment.NewLine + System.Environment.NewLine
                            /* + "************* Item Units *************" + System.Environment.NewLine 
                             System.Environment.NewLine + i22.Text + System.Environment.NewLine
                             +" Price per-Unit " + System.Environment.NewLine +
                             System.Environment.NewLine + i33.Text + System.Environment.NewLine */
                                       + "************* Grand Total *************" + System.Environment.NewLine +
                                       System.Environment.NewLine + i44.Text + System.Environment.NewLine;

                        // System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
                        sw.Write(text2write);
                        sw.Close();


                    }


                }

                
                }
                


            
            catch
            {
                MessageBox.Show("problem accured");
            }



        }

        private void search_Click(object sender, RoutedEventArgs e)
        {

            string filename = @"" + pathtb.Text + "" + c22.Text + ".txt";

            TextRange range;
            FileStream fStream;

            if (File.Exists(filename))
            {
                range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                fStream = new FileStream(filename, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Text);
                fStream.Close();

            }


        }

        private void coustnew_Click(object sender, RoutedEventArgs e)
        {
            c11.Text = c22.Text = c33.Text = c44.Text = c55.Text = i11.Text = i22.Text = i33.Text = i44.Text = "" ;
            rtb1.Document.Blocks.Clear();
        }
    }
}
