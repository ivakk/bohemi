using LogicLayer;
using Classes;
using DesktopApplication.Forms.AlcoholSubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfacesLL;
using DataAccessLayer;
using Microsoft.VisualBasic.Devices;

namespace DesktopApplication.Forms
{
    public partial class AlcoholForm : Form
    {
        public Menu menu;
        AddAlcoholForm addAlcoholForm;

        private readonly IAlcoholService _alcoholService;


        public AlcoholForm(Menu menu, IAlcoholService _alcoholService)
        {
            InitializeComponent();
            this._alcoholService = _alcoholService;

            addAlcoholForm = new AlcoholSubForms.AddAlcoholForm(this, _alcoholService) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.menu = menu;
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            dgvAlcohols.DataSource = _alcoholService.GetAllAlcohols();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvAlcohols.DataSource = _alcoholService.GetAlcoholsBySearch(tbSearch.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Alcohol alcohol = (Alcohol)dgvAlcohols.CurrentRow.DataBoundItem;
            addAlcoholForm.SetAlcoholId(alcohol.Id);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(addAlcoholForm);
            addAlcoholForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Alcohol alcohol = (Alcohol)dgvAlcohols.CurrentRow.DataBoundItem;
            _alcoholService.DeleteAlcohol(alcohol.Id);
            dgvAlcohols.DataSource = _alcoholService.GetAllAlcohols();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addAlcoholForm.SetAlcoholId(0);
            menu.pnlMain.Controls.Clear();
            this.menu.pnlMain.Controls.Add(addAlcoholForm);
            addAlcoholForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvAlcohols.DataSource = _alcoholService.GetAlcoholsBySearch("");
        }
    }
}
