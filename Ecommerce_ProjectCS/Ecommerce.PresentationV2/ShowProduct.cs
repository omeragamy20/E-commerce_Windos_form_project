using Autofac;
using AutoMapper;
using Ecommerce.Application.AutoMapper;
using Ecommerce.Application.Services;
using Ecommerce.DTOs.Product;
using Ecommerce.Inftastructure;
using Ecommerce.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Ecommerce.Application.Contracts;

namespace Ecommerce.PresentationV2
{
    public partial class ShowProduct : Form
    {
        private IProductRepository ProductRepositor;

        private IUserService userSrvice;



        private List<GetAllProductDTO> products;
        private int num = 1;

        product_details ProductForm;

        DataGridViewButtonColumn ProductDtails;
        DataGridViewButtonColumn buttonColumn;

        public ShowProduct()
        {
            InitializeComponent();
            products = new List<GetAllProductDTO>();

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            //int productIdColumnIndex = e.ColumnIndex;

            //if (productIdColumnIndex >= 0 && productIdColumnIndex < dataGridView1.Columns.Count)
            //{
            //    string productId = dataGridView1.Rows[e.RowIndex].Cells[productIdColumnIndex].Value.ToString();

            //    product_details productForm = new product_details(int.Parse(productId));
            //    productForm.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Product ID column not found. Please ensure it exists before the button column.");
            //}
            //////////////////
            //
            if (e.ColumnIndex == dataGridView1.Columns["Add_Cart"].Index && e.RowIndex >= 0)
            {
                var selectedProduct = dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                var container = AutoFac.AutoFac.Inject();

                IUserService user = container.Resolve<IUserService>();
                IProductService productService = container.Resolve<IProductService>();
                IOrderService orderService = container.Resolve<IOrderService>();

                int userid = user.GetActiveUser().Id;
                ProductDetailsDTO productDetails = productService.GetProductById((int)selectedProduct);
                orderService.CreateOrder(new DTOs.Order.OrderDto
                {
                    OrderDate = DateTime.Now,
                    ProductId = productDetails.Id,
                    Quantity = 1,
                    Status = "pending",
                    UserId = userid,
                });
            }

            else if (e.ColumnIndex == dataGridView1.Columns["ShowProductDetails"].Index && e.RowIndex >= 0)
            {
                var selectedProduct = dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                var container = AutoFac.AutoFac.Inject();
                IProductService productService = container.Resolve<IProductService>();
                //int x = selectedProduct;
                ProductDetailsDTO productDetails = productService.GetProductById((int)selectedProduct);
                ProductForm = new product_details(productDetails.Id);

                //ProductFrm.PCategory = productDetails.Category.Name;

                ProductForm.PImage = imageURLToBitmap(productDetails.ImageURL);


                product_details product_Details = new product_details(productDetails.Id);
                this.Hide();

                product_Details.Show();

            }


        }

        private void ShowProduct_Load(object sender, EventArgs e)
        {

            var container = AutoFac.AutoFac.Inject();
            IProductService productService = container.Resolve<IProductService>();
            BindingList<GetAllProductDTO> products = new BindingList<GetAllProductDTO>(productService.GetAllProudctPagination(4, 1));
            dataGridView1.DataSource = products;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            // Hide row headers
            dataGridView1.RowHeadersVisible = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }


            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                HeaderText = "Image",
                Name = "Image",
                Width = 300,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 70;
            }
            dataGridView1.Columns.Add(imageColumn);
            for (int i = 0; i < products.Count; i++)
            {
                string prodImageURL = products[i].ImageURL;
                Image pic = imageURLToBitmap(prodImageURL);

                if (pic != null)
                {
                    dataGridView1.Rows[i].Cells["Image"].Value = pic;
                }
            }


            //dataGridView1.Columns.Add(ProductDtails);

            //dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;


            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Add_Cart",
                Name = "Add_Cart",
                Text = "Add_Cart",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            dataGridView1.Columns.Add(buttonColumn);

            DataGridViewButtonColumn ProductDtails = new DataGridViewButtonColumn
            {
                HeaderText = "Check Out This Product",
                Name = "ShowProductDetails",
                Text = "ShowProductDetails",
                UseColumnTextForButtonValue = true,
                Width = 140
            };

            dataGridView1.Columns.Add(ProductDtails);



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

        //CreatOrderHiddenIDDTO orderMaster;
        //CreateOrderDetailDTO OrderItem;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ()
            //{

            //}


            //  if (e.ColumnIndex == ProductDtails.Index)
            //{
            //int productIdColumnIndex = e.ColumnIndex;

            //if (productIdColumnIndex >= 0 && productIdColumnIndex < dataGridView1.Columns.Count)
            //{
            //    string productId = dataGridView1.Rows[e.RowIndex].Cells[productIdColumnIndex].Value.ToString();

            //    product_details productForm = new product_details(int.Parse(productId));
            //    productForm.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Product ID column not found. Please ensure it exists before the button column.");
            //}
            //  }
            //else
            //{
            //    MessageBox.Show("Product ID column not found. Please ensure it exists before the button column.");


            //}
        }


        //        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        {
        //           // if ()
        //            //{

        ////            }

        //                if (e.ColumnIndex == dataGridView1.Columns["ShowProductDetails"].Index && e.RowIndex >= 0)
        //                {
        //                    var selectedProduct = dataGridView1.Rows[e.RowIndex].DataBoundItem as GetAllProductsDTO;

        //                    var container = AutoFac.AutoFac.Inject();
        //                    IProductService productService = container.Resolve<IProductService>();
        //                    ProductDetailsDTO productDetails = productService.GetProductDetails(selectedProduct);
        //                    ProductForm = new product_details(selectedProduct.Id);

        //                    //ProductFrm.PCategory = productDetails.Category.Name;

        //                    ProductForm.PImage = imageURLToBitmap(productDetails.ImageURL);


        //                    product_details product_Details = new product_details(selectedProduct.Id);
        //                    this.Hide();

        //                    product_Details.Show();

        //                }

        //   }



        private void Nextbtn_Click(object sender, EventArgs e)
        {
            num++;
            var container = AutoFac.AutoFac.Inject();
            IProductService productService = container.Resolve<IProductService>();
            BindingList<GetAllProductDTO> products = new BindingList<GetAllProductDTO>(productService.GetAllProudctPagination(4, num));

            dataGridView1.DataSource = products;
            for (int i = 0; i < products.Count; i++)
            {
                string prodImageURL = products[i].ImageURL;
                Image pic = imageURLToBitmap(prodImageURL);
                if (pic != null)
                {
                    dataGridView1.Rows[i].Cells["Image"].Value = pic;
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 100;
            }

        }

        private void Prevbtn_Click(object sender, EventArgs e)
        {
            if (num > 1)
            {
                num--;
                var container = AutoFac.AutoFac.Inject();
                IProductService productService = container.Resolve<IProductService>();
                BindingList<GetAllProductDTO> products = new BindingList<GetAllProductDTO>(productService.GetAllProudctPagination(4, num));

                dataGridView1.DataSource = products;
                for (int i = 0; i < products.Count; i++)
                {
                    string prodImageURL = products[i].ImageURL;
                    Image pic = imageURLToBitmap(prodImageURL);
                    if (pic != null)
                    {
                        dataGridView1.Rows[i].Cells["Image"].Value = pic;
                    }
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 100;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SearchName = comboBoxCategory.Text;

            var container = AutoFac.AutoFac.Inject();
            IProductService productService = container.Resolve<IProductService>();
            BindingList<GetAllProductDTO> products = new BindingList<GetAllProductDTO>(productService.SearchProduct(SearchName, num, num));


            dataGridView1.DataSource = products;
            for (int i = 0; i < products.Count; i++)
            {
                string prodImageURL = products[i].ImageURL;
                Image pic = imageURLToBitmap(prodImageURL);
                if (pic != null)
                {
                    dataGridView1.Rows[i].Cells["Image"].Value = pic;
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 100;
            }


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Cartbtn_Click(object sender, EventArgs e)
        {

            //var container = AutoFac.AutoFac.Inject();
            //IUserService orderService = container.Resolve<IUserService>();

            //var user = orderService.GetActiveUser();

            orderForm oder = new orderForm();
            this.Hide();
            oder.Show();
            // this.Hide();

        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
