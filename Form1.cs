﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormShopORM.Controller;
using WinFormShopORM.Model;

namespace WinFormShopORM
{
    public partial class Form1 : Form
    {
        ProductLogic productController = new ProductLogic();
        ProductTypeLogic productTypeController = new ProductTypeLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //List<ProductType> productTypes = new List<ProductType>();
            //cmbType.DataSource = productTypes;
            //cmbType.DisplayMember = "Name";
            //cmbType.ValueMember = "Id";


        }

        private void LoadRecord(Product product)
        {
            txtId.BackColor = Color.White;
            txtId.Text = product.Id.ToString();
            txtPrice.Text = product.Price.ToString();
            cmbType.Text = product.ProductType.Name;
            txtDesc.Text = product.Description;
            txtExpiry.Text = product.Expiry;
            txtBrand.Text = product.Brand.ToString();   
        }

        private void ClearScreen()
        {
            txtId.BackColor= Color.White;
            txtId.Text = "";
            txtBrand.Text = "";
            txtDesc.Text = "";
            txtExpiry.Text = "";
            txtPrice.Text = "";
            cmbType.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ID!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            Product product = new Product();
           
            product.Brand = txtBrand.Text;
            product.Description = txtDesc.Text;
            product.Price = double.Parse(txtPrice.Text);
            product.Expiry = txtExpiry.Text;
            product.ProductTypeId = (int)cmbType.SelectedValue;
            
            
           

            productController.Create(product);
          
            

            productController.Create(product);
            MessageBox.Show("Продуктът е успешно добавен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearScreen();
            btnSelectAll_Click(sender, e);
            

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Product> products = productController.GetProducts();
            listBox1.Items.Clear();

            foreach (var i in products)
            {
                listBox1.Items.Add($"{i.Id}. Вид : {i.ProductType.Name} Марка : {i.Brand} Цена : {i.Price}" +
                    $" Описание : {i.Description} Срок на годност : {i.Expiry}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ID!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }

            else
            {
                findId = int.Parse(txtId.Text);
            }

            

            if (string.IsNullOrEmpty(txtBrand.Text))
            {

                Product findProduct = productController.Get(findId);

                if (findProduct == null)
                {
                    DialogResult dr = MessageBox.Show("Не бе намерен продукт с посоченото ID!", "Грешка!",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (dr == DialogResult.Retry)
                    {
                        txtId.BackColor = Color.Red;
                        txtId.Text = "";
                        txtId.Focus();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                LoadRecord(findProduct);

            }

            else
            {
                Product updatedProduct = new Product();
                updatedProduct.Brand = txtBrand.Text;
                updatedProduct.Description = txtDesc.Text;
                updatedProduct.Price = double.Parse(txtPrice.Text);
                updatedProduct.Expiry = txtExpiry.Text;
                updatedProduct.ProductTypeId = (int)cmbType.SelectedValue;

                productController.Update(findId, updatedProduct);
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи ID!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }

            else
            {
                findId = int.Parse(txtId.Text);
            }

            if (string.IsNullOrEmpty(txtBrand.Text))
            {
                Product findProduct = productController.Get(findId);

                if (findProduct == null)
                {
                    DialogResult dr = MessageBox.Show("Не бе намерен продукт с посоченото ID!", "Грешка!",
                       MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (dr == DialogResult.Retry)
                    {
                        txtId.BackColor = Color.Red;
                        txtId.Text = "";
                        txtId.Focus();
                        return;
                    }

                    else
                    {
                        return;
                    }
                }
                LoadRecord(findProduct);



            }

            else
            {
                DialogResult dr = MessageBox.Show("Желате ли да изтриете следния запис?", "Внимание!",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                productController.Delete(findId);

                if (dr == DialogResult.Yes)
                {
                    productController.Delete(findId);
                    return;
                }

                btnSelectAll_Click(sender, e);
            }

           







        }
    }
}
