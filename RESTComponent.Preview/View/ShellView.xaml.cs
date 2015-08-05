// RESTComponent
// RESTComponent.Preview
// ShellView.xaml.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using RESTComponent.Preview.ViewModel;

namespace RESTComponent.Preview.View
{
    public partial class ShellView
    {
        public ShellView(IPreviewViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        private IPreviewViewModel ViewModel
        {
            get { return (IPreviewViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}