   M S B A M L   `   `   `  ����F  BMVVM_Person, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM_PersonMVVM_Person  5   	   ?$clr-namespace:MVVM_Person.ViewModelsMVVM_Person.ViewModels  5   	       MVVM_Person.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MVVM_Person     5   	   3vm$clr-namespace:MVVM_Person.ViewModels     5   	     � Title$
  Mvvm��5	   	   $	��450��6   $��634.603��6#    � 	Resources 5
      ,   &MVVM_Person.ViewModels.PersonViewModel 
  person��%   &	          5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $��* �6   $	��280��6)   �� 5      $
��1.8* �6   .+�5   
   �� $��10q�6   $��0��6!   .+�5      �� $��Imię��6   �� 5      -   5         ��Name$ 
bordername��5      $	��0.7q�6)   
�������._�5      �� ��6   �� *	BoxName+ �� Mode$ TwoWay=�5      �� 5      $��Nazwisko��6   �� 5      -   5        $ borderlastName��5      $	��0.7q�6-   
�������._�5      �� ��6   �� *BoxlastName+$ TwoWay=�5      �� 5       -   5         ��Name$ labelAge��5       ��6&   �� *
LabelAge+$ OneWay=��� 5!      -   5        $��	sliderAge��5!       � Minimum$ 0Q�6&    � Maximum$	 200Q�62   	 �� IsSnapToTickEnabled	 . 
 �� TickFrequency$
 1Q�5"   0    � Value 5!   @   �� *	SliderAge+$ TwoWay=�5"   0   �� 5$      -   5        $ labelWeight��5$      ��6)   �� *LabelWeight+$ OneWay=��� 5%      -   5        $��sliderWeight��5%      $ 0Q�6)   $	 200Q�65   	 . $
 1Q�5&   0    5%   C   �� *SliderWeight+$ TwoWay=�5&   0   �� 5)      -   5         ��Name$ IC_dodaj��5)      $��Dodaj��5*      ��5)   '   �� *
IC_dodaj+5*      �� 5+      -   5        $ edytuj_przycisk��5+      $��Edytuj��5,      ��5+   .   �� *	IC_edycja+5,      �� 5-      -	   5        $ IC_usun��5-      $��Usuń��5.      ��5-   &   �� *	IC_usun+5.      53      �� 56   
   $��1��6   ��6"   �� *
Lista_osob+ �� SelectedIndex 6E   �� *Id+��57      �� 58      .R�59      ��  �� Orientation$ 
Horizontal=�6!   .+�5:      �� $��50��69   ��6$   �� *ALL+69   5;      5<      5>      5?      5@      