using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVM_Person.Comand;
using MVVM_Person.Model;

namespace MVVM_Person.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly string path = "dane.txt";

        private ObservableCollection<Person> lista = new ObservableCollection<Person>();
        private int _Id = -1;

        private string nameBox = "";
        private string lastNameBox = "";
        private int sliderW = 0;
        private int sliderA = 0;

        public string BoxName
        {
            get { return nameBox; }
            set { nameBox = value; OnPropertyChanged(nameof(BoxName)); }
        }

        public string BoxlastName
        {
            get { return lastNameBox; }
            set { lastNameBox = value; OnPropertyChanged(nameof(BoxlastName)); }
        }

        public int SliderAge
        {
            get { return sliderA; }
            set { sliderA = value; OnPropertyChanged(nameof(SliderAge), nameof(LabelAge)); }
        }

        public int SliderWeight
        {
            get { return sliderW; }
            set { sliderW = value; OnPropertyChanged(nameof(SliderWeight), nameof(LabelWeight)); }
        }

        public string LabelAge
        {
            get { return $"Wiek ({sliderA})"; }
        }

        public string LabelWeight
        {
            get { return $"Waga ({sliderW})"; }
        }

        private ICommand dodaj_przycisk = null;
        private ICommand usun_przycisk = null;
        private ICommand edytuj_przycisk = null;
        private ICommand wczytaj = null;
        private ICommand zapisz = null;

        public PersonViewModel()
        {
            if (File.Exists(path))
            {
                Lista_osob = new ObservableCollection<Person>(Serializacja_wczytaj_zapisz.LoadData(path));
            }
        }

        private bool CzyDodac(string text)
        {
            if (String.IsNullOrEmpty(text))
                return false;
            if (Regex.IsMatch(text, @"\d"))
                return false;
            return true;
        }

        private void Dodaj()
        {
            lista.Add(new Person(BoxName, BoxlastName, SliderWeight, SliderAge));
            Serializacja_wczytaj_zapisz.RecordData(path, Lista_osob.ToList());
        }

        private void Usun()
        {
            var atIndex = Id;
            var dialogResult = MessageBox.Show("Czy na pewno usunąć?", "Usuń", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                Id = -1;
                Lista_osob.RemoveAt(atIndex);
                Serializacja_wczytaj_zapisz.RecordData(path, Lista_osob.ToList());
            }
        }

        private void Edytuj()
        {
            var dialogResult = MessageBox.Show("Czy edytować?", "Edytuj", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                Lista_osob.Insert(Id, new Person(BoxName, BoxlastName, SliderWeight, SliderAge));
                Id -= 1;
                Lista_osob.RemoveAt(Id + 1);
                Serializacja_wczytaj_zapisz.RecordData(path, Lista_osob.ToList());
            }
        }

        #region Get/Set Commands
        public ICommand IC_wczytaj
        {
            get
            {
                if (wczytaj == null)
                {
                    ComandList comandList = new ComandList(arg => Lista_osob = new ObservableCollection<Person>(Serializacja_wczytaj_zapisz.LoadData(path)),arg => File.Exists(path));
                    wczytaj = comandList;
                }
                return wczytaj;
            }
        }

        public ICommand IC_zapisz
        {
            get
            {
                if (zapisz == null)
                {
                    ComandList comandList = new ComandList(arg => Serializacja_wczytaj_zapisz.RecordData(path, Lista_osob.ToList()),arg => true);
                    zapisz = comandList;
                }
                return zapisz;
            }
        }

        public ICommand IC_edycja
        {
            get
            {
                if (edytuj_przycisk == null)
                {
                    ComandList comandList = new ComandList(arg => Edytuj(),arg => CzyDodac(BoxName) && CzyDodac(BoxlastName) && Id > -1);
                    edytuj_przycisk = comandList;
                }
                return edytuj_przycisk;
            }
        }

        public ICommand IC_usun
        {
            get
            {
                if (usun_przycisk == null)
                {
                    ComandList comandList = new ComandList(arg => Usun(),arg => Id > -1);
                    usun_przycisk = comandList;
                }
                return usun_przycisk;
            }
        }

        public ICommand IC_dodaj
        {
            get
            {
                if (dodaj_przycisk == null)
                {
                    ComandList comandList = new ComandList(arg => Dodaj(),arg => CzyDodac(BoxName) && CzyDodac(BoxlastName));
                    dodaj_przycisk = comandList;
                }
                return dodaj_przycisk;
            }
        }
        #endregion


        public ObservableCollection<Person> Lista_osob
        {
            get
            {
                return lista;
            }
            set
            {
                lista = value;
                OnPropertyChanged(nameof(Lista_osob));
            }
        }

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;

                if (_Id > -1)
                {
                    BoxName = Lista_osob[_Id].Name;
                    BoxlastName = Lista_osob[_Id].LastName;
                    SliderAge = Lista_osob[_Id].Age;
                    SliderWeight = Lista_osob[_Id].Weight;
                }
                else
                {
                    BoxName = "";
                    BoxlastName = "";
                    SliderAge = 0;
                    SliderWeight = 0;
                }

                OnPropertyChanged(nameof(Id));
            }
        }


        

    }
}
