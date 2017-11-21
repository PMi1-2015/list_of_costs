﻿using ListOfCosts.db_client;
using ListOfCosts.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ListOfCosts.ViewModels
{
    class AddResourceViewModel: DependencyObject
    {
        private readonly int _id = 0;

        public ObservableCollection<Category> Categories
        {
            get { return (ObservableCollection<Category>)GetValue(CategoriesProperty); }
            set { SetValue(CategoriesProperty, value); }
        }

        public static readonly DependencyProperty CategoriesProperty =
            DependencyProperty.Register("Categories", typeof(ObservableCollection<Category>), typeof(AddResourceViewModel), new PropertyMetadata(new ObservableCollection<Category>()));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AddResourceViewModel), new PropertyMetadata(""));

        public double Amount
        {
            get { return (double)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(double), typeof(AddResourceViewModel), new PropertyMetadata(0.0));

        public int SelectedCategory
        {
            get { return (int)GetValue(SelectedCategoryProperty); }
            set { SetValue(SelectedCategoryProperty, value); }
        }

        public static readonly DependencyProperty SelectedCategoryProperty =
            DependencyProperty.Register("SelectedCategory", typeof(int), typeof(AddResourceViewModel), new PropertyMetadata(0));

        public AddResourceViewModel()
        {
            ResourceCategoryDbStrategy s = new ResourceCategoryDbStrategy();

            foreach(var c in s.ReadAll())
            {
                Categories.Add(c);
            }
        }

        public AddResourceViewModel(int id)
        {
            _id = id;

            ResourceCategoryDbStrategy s = new ResourceCategoryDbStrategy();

            foreach (var c in s.ReadAll())
            {
                Categories.Add(c);
            }

            Resource toGet = new ResourceDbStrategy().Read<int, Resource>(id);

            Title = toGet.Title;
            Amount = toGet.Amount;
            SelectedCategory = toGet.ResourceType.Id;
        }

        public void Add()
        {
            ResourceDbStrategy s = new ResourceDbStrategy();
            Resource r = new Resource()
            {
                 Id = _id,
                 Amount = Amount,
                 ResourceType = new Category()
                 {
                      Id = SelectedCategory,
                      Name = Categories.Where(x => x.Id == SelectedCategory).First().Name
                 },
                 Title = Title
            };

            if(_id != 0)
            {
                s.Update(r);
            }
            else
            {
                s.Create(r);
            }

        }
    }
}