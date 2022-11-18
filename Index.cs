using System.Windows.Forms;
using System;

namespace FantasyFootballFriend {
    public partial class Index : Form {
        Controller controller;
        public Index() {
            InitializeComponent();
            controller = new Controller();
        }

        private void uxSearchButton_Click(object sender, EventArgs e) {
            Search searchForm = new Search();
            searchForm.SetController(controller);
            searchForm.Show();
        }

        private void uxAddButton_Click(object sender, EventArgs e) {
            Add addForm = new Add();
            addForm.SetController(controller);
            addForm.Show();
        }

        // Don't use and dont delete
        private void uxDeleteButton_Click(object sender, EventArgs e) {
            Delete deleteForm = new Delete();
            //deleteForm.SetController(controller);
            deleteForm.Show();
        }
    }
}