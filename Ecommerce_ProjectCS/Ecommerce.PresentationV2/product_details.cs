using Ecommerce.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Autofac;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ecommerce.DTOs.Product;
using System.Diagnostics;
using System.Net;
using Ecommerce.Models;

namespace Ecommerce.PresentationV2
{
    public partial class product_details : Form
    {
        int productID;


        public product_details(int id)
        {
            InitializeComponent();
            productID = id;

        }

        public string PName;
        public decimal PPrice;
        public int PStock;
        public bool PDiscount;
        public string PImgURL;
        public string PCategory;
        public Image PImage;

        private void product_details_Load(object sender, EventArgs e)
        {
            var container = AutoFac.AutoFac.Inject();
            IProductService productService = container.Resolve<IProductService>();
            ProductDetailsDTO pdto = productService.GetProductById(productID);
            Price.Text = pdto.Price.ToString();
            Description.Text = pdto.ProductDescription;
            // textname.Text= pdto.Name;
            LB_Name.Text = pdto.ProductName;

            // string prodImageURL = products[i].ImageURL;
            Image pic = imageURLToBitmap(pdto.ImageURL);

            pictureBox1.Image = pic;




        }
        Bitmap imageURLToBitmap(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return new Bitmap(response.GetResponseStream());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching image: {ex.Message}");
                return null;
            }
        }

        private void Price_Click(object sender, EventArgs e)
        {

        }

        private void LB_Name_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            ShowProduct sh= new ShowProduct();
            this.Hide();
            sh.Show();
        }
    }
}
