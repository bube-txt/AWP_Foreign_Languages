using AWP_Foreign_Languages_WPF.Models;
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

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Administrator.Frame
{
    /// <summary>
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        Core db = new Core();
        List<ServiceTeacher> serviceTeachers;
        List<Service> services;
        List<Teacher> teachers;
        ServiceTeacher lastSelected;
        public TeachersPage()
        {
            InitializeComponent();

            services = db.context.Service.ToList();
            teachers = db.context.Teacher.ToList();
            Update();


            ComboBoxServiceSearch.ItemsSource = services;
            ComboBoxServiceSearch.DisplayMemberPath = "NameService";
            ComboBoxServiceSearch.SelectedValuePath = "IdService";

            ComboBoxTeacherSearch.ItemsSource = teachers;
            ComboBoxTeacherSearch.DisplayMemberPath = "FullName";
            ComboBoxTeacherSearch.SelectedValuePath = "IdTeacher";

            ComboBoxServiceAdd.ItemsSource = services;
            ComboBoxServiceAdd.DisplayMemberPath = "NameService";
            ComboBoxServiceAdd.SelectedValuePath = "IdService";

            ComboBoxTeacherAdd.ItemsSource = teachers;
            ComboBoxTeacherAdd.DisplayMemberPath = "FullName";
            ComboBoxTeacherAdd.SelectedValuePath = "IdTeacher";

            ComboBoxServiceEdit.ItemsSource = services;
            ComboBoxServiceEdit.DisplayMemberPath = "NameService";
            ComboBoxServiceEdit.SelectedValuePath = "IdService";

            ComboBoxTeacherEdit.ItemsSource = teachers;
            ComboBoxTeacherEdit.DisplayMemberPath = "FullName";
            ComboBoxTeacherEdit.SelectedValuePath = "IdTeacher";
        }

        private void Update(){
            serviceTeachers = db.context.ServiceTeacher.ToList();
            DataGridTeacherService.ItemsSource = serviceTeachers;
        }

        private void Search()
        {
            if (ComboBoxServiceSearch.SelectedIndex != -1)
            {
                serviceTeachers = serviceTeachers.Where(x => x.Service.IdService == (int)ComboBoxServiceSearch.SelectedValue).ToList();
            }
            if (ComboBoxTeacherSearch.SelectedIndex != -1)
            {
                serviceTeachers = serviceTeachers.Where(x => x.Teacher.IdTeacher == (int)ComboBoxTeacherSearch.SelectedValue).ToList();
            }
            DataGridTeacherService.ItemsSource = serviceTeachers;
        }

        private void ComboBoxServiceSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void ComboBoxTeacherSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void DataGridTeacherService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ServiceTeacher)DataGridTeacherService.SelectedItem != null)
            {
                lastSelected = (ServiceTeacher)DataGridTeacherService.SelectedItem;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if ((ServiceTeacher)DataGridTeacherService.SelectedItem != null)
            {
                ComboBoxServiceEdit.SelectedValue = lastSelected.IdService;
                ComboBoxTeacherEdit.SelectedValue = lastSelected.IdTeacher;
            }   
        }

        private void ButtonEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (
                lastSelected != null &&
                ComboBoxServiceAdd.SelectedIndex != -1 &&
                ComboBoxTeacherAdd.SelectedIndex != -1
                )
            {
                lastSelected.IdService = (int)ComboBoxServiceEdit.SelectedValue;
                lastSelected.IdTeacher = (int)ComboBoxTeacherEdit.SelectedValue;

                db.context.SaveChanges();
                Update();
            }
        }

        private void ButtonClearEdit_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxServiceEdit.SelectedIndex = -1;
            ComboBoxTeacherEdit.SelectedIndex = -1;
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if ((ServiceTeacher)DataGridTeacherService.SelectedItem != null)
            {
                db.context.ServiceTeacher.Remove(lastSelected);
                db.context.SaveChanges();

                Update();
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxServiceSearch.SelectedIndex = -1;
            ComboBoxTeacherSearch.SelectedIndex = -1;
        }

        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxServiceAdd.SelectedIndex = -1;
            ComboBoxTeacherAdd.SelectedIndex = -1;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Add()
        {
            if (
                ComboBoxServiceAdd.SelectedIndex != -1 &&
                ComboBoxTeacherAdd.SelectedIndex != -1
                )
            {
                ServiceTeacher st = new ServiceTeacher
                {
                    IdService = (int)ComboBoxServiceAdd.SelectedValue,
                    IdTeacher = (int)ComboBoxTeacherAdd.SelectedValue,
                };

                db.context.ServiceTeacher.Add(st);
                db.context.SaveChanges();
                Update();
            }
        }
    }
}
