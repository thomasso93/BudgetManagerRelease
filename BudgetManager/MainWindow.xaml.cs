using System.Windows;
using BudgetManager.Model;
using BudgetManager.ViewModel;

namespace BudgetManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

       // private bool _nameChanged = false;
       // private bool _categoryChanged = false;
       // private bool _amountChanged = false;

        //private ExpenseWindowViewModel model = new ExpenseWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            initCategoryBox();
            initIncomeCategoryBox();
            ExpenseWindowViewModel model = new ExpenseWindowViewModel();
            DataContext = model;     
        }

        private void initCategoryBox() {
            foreach (string current in Category._categories) {
                categoryBox.Items.Add(current);
            }
        }

        private void initIncomeCategoryBox()
        {
            foreach (string current in CategoryIncome._categories)
            {
                incomeCategoryBox.Items.Add(current);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //string name = expenseNameTxtBox.Text;
            //string category = categoryBox.Text;
            //string amount = expenseAmountBox.Text;
        }

        private void expenseNameTxtBoxChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           // _nameChanged = true;
            //if ((_categoryChanged == true) && (_amountChanged == true))
              //  saveButton.IsEnabled = true;
        }

        private void categoryBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           // _categoryChanged = true;
            //if ((_nameChanged == true) && (_amountChanged == true))
            //   saveButton.IsEnabled = true;
            //checkSubCategory(categoryBox.Text);
        }

        private void expenseAmountBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            //_amountChanged = true;
            //if ((_categoryChanged == true) && (_categoryChanged == true))
             //   saveButton.IsEnabled = true;
        }

        private void incomeNameTxtBoxChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void incomeCategoryBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void incomeAmountBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

             
    }
}