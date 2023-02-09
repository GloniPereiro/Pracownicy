using Crud.domain.Model;
using Crud.EF;
using System;
using System.Collections.Generic;
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

namespace Crud.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ListaPracownikowCrudServices _crudServices;
        private readonly ListaZadanCrudServices _HistoryServices;
        public MainWindow()
        {
            InitializeComponent();
            _crudServices = new ListaPracownikowCrudServices();
            _HistoryServices = new ListaZadanCrudServices();

            ButtonAdd.Click += ButtonAdd_Click;
            ButtonList.Click += ButtonList_Click;
            DataGridBrand.SelectionChanged += DataGridBrand_SelectionChanged;

            ButtonHistoryList.Click += ButtonHistoryList_Click;
/*            DataGridHistoryBrand.SelectionChanged += DataGridHistoryBrand_SelectionChanged;
*/            ButtonHistorySearch.Click += ButtonHistorySearch_Click;

            ButtonEdit.Click += ButtonEdit_Click;

            ButtonDelete.Click += ButtonDelete_Click;


            ButtonSearch.Click += ButtonSearch_Click;
        }

        private async void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtProductID.Text != string.Empty && txtProduct.Text != string.Empty)
                {
                    await _crudServices.UpdateBrand(int.Parse(txtProductID.Text), txtProduct.Text);
                    throw new Exception("Data Successfully Updateddd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await ListBrands();
            }


        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text != string.Empty && txtProduct.Text != string.Empty )
                {
                    await _crudServices.DeleteBrand(int.Parse(txtProductID.Text));
                    throw new Exception("Data Successfully Deleteddd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await ListBrands();
            }
        }

        private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var SearchName = await _crudServices.SearchBrandByName(txtProduct.Text);
            DataGridBrand.ItemsSource = SearchName.ToList();
        }
        private async void ButtonHistorySearch_Click(object sender, RoutedEventArgs e)
        {
            var SearchName = await _HistoryServices.SearchHistoryBrandByName(txtProduct1.Text);
            DataHistoryGridBrand.ItemsSource = SearchName.ToList();
        }

        private void DataGridBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var activelist = (ListaPracownikow)DataGridBrand.CurrentItem;


                if (activelist != null)
                {
                    txtProductID.Text = activelist.IdPracownika.ToString();
                    txtProduct.Text = activelist.Imie;

                    txtProduct1.Text = activelist.Imie;
                    txtID2.Text = activelist.IdPracownika.ToString();

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataHistoryGridBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var activelist = (ListaZadan)DataHistoryGridBrand.CurrentItem;

                if (activelist != null)
                {
                    txtProductID.Text = activelist.IdZadania.ToString();
                    txtProduct.Text = activelist.Pracownik;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                await ListBrands();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void ButtonHistoryList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ListHistoryBrands();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ListBrands()
        {
            var brandList = await _crudServices.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList();
        }
        private async Task ListHistoryBrands()
        {
            var brandList = await _HistoryServices.ListHistoryBrands();
            DataHistoryGridBrand.ItemsSource = brandList.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudServices.AddBrand(txtProduct.Text);



                throw new Exception("Data Successfully Addedd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                txtProductID.Clear();
                txtProduct.Clear();
                txtProductID.Focus();
            }
        }

        private void ButtonHistoryAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _HistoryServices.AddHistoryBrand(txtKategoria.Text,txtOpis.Text, txtProduct1.Text );
                _crudServices.UpdateNiezakonczone(int.Parse(txtProductID.Text));

                throw new Exception("Data Successfully Addedd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                txtKategoria.Clear();
                txtOpis.Clear();
                txtProductID.Focus();
            }
        }

       
    }


}
