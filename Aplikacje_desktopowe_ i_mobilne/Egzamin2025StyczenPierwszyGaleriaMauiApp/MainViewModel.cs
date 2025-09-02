using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Egzamin2025StyczenPierwszyGaleriaMauiApp
{
    internal class MainViewModel : BindableObject
    {
		private bool showFlowers;
		public bool ShowFlowers
        {
			get { return showFlowers; }
			set
			{ 
				showFlowers = value;
				OnPropertyChanged();
                FilterGallery();

            }
		}

        private bool showAnimals;
        public bool ShowAnimals
        {
            get { return showAnimals; }
            set
            {
                showAnimals = value;
                OnPropertyChanged();
                FilterGallery();
            }
        }

        private bool showCars;
        public bool ShowCars
        {
            get { return showCars; }
            set
            {
                showCars = value;
                OnPropertyChanged();
                FilterGallery();
            }
        }

        private List<ImageComponent> gallery;

        public List<ImageComponent> Gallery
        {
            get { return gallery; }
            set 
            { 
                gallery = value;
                OnPropertyChanged();
            }
        }

        private ICommand downloadCommand;

        public ICommand DownloadCommand
        {
            get 
            { 
                if (downloadCommand == null)
                {
                    downloadCommand = new Command<ImageComponent>(
                        ic =>
                        {
                            ic.Downloads++;
                        }
                        );
                }
                return downloadCommand; 
            }
        }


        private List<ImageComponent> allImages;

        public MainViewModel()
        {
            allImages = new List<ImageComponent>()
            { 
                new ImageComponent()
                {
                    Id = 0, Alt = "Mak", FileName = "obraz1.jpg", Category = 1, Downloads = 35, DownloadCommand = DownloadCommand
                },
                new ImageComponent()
                {
                    Id = 1, Alt = "Bukiet", FileName = "obraz2.jpg", Category = 1, Downloads = 43, DownloadCommand = DownloadCommand
                },
                new ImageComponent()
                {
                    Id = 2, Alt = "Dalmatyńczyk", FileName = "obraz3.jpg", Category = 2, Downloads = 2, DownloadCommand = DownloadCommand
                },
                new ImageComponent()
                {
                    Id = 3, Alt = "Świnka morska", FileName = "obraz4.jpg", Category = 2, Downloads = 53, DownloadCommand = DownloadCommand
                },
                new ImageComponent()
                {
                    Id = 4, Alt = "Rotwailer", FileName = "obraz5.jpg", Category = 2, Downloads = 43, DownloadCommand = DownloadCommand
                },
                new ImageComponent()
                {
                    Id = 5, Alt = "Audi", FileName = "obraz6.jpg", Category = 3, Downloads = 11, DownloadCommand = DownloadCommand
                },
            };

            showFlowers = true;
            showAnimals = true;
            showCars = true;
            FilterGallery();
        }

        private void FilterGallery()
        {
            Gallery = allImages
                .Where(ic => (ShowFlowers && ic.Category == 1)
                            || (ShowAnimals && ic.Category == 2)
                            || (ShowCars && ic.Category == 3))
                .ToList();
        }

    }
}
