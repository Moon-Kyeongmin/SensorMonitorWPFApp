   M S B A M L   `   `   `  ����N  JSensorMonitorWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SensorMonitorWPFApp.ViewsSensorMonitorWPFApp.Views  5      (    "SensorMonitorWPFApp.Views.InfoView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      3local'clr-namespace:SensorMonitorWPFApp.Views  5      
�������  � 
ResizeMode$  NoResize=�5	   N    � Title$# 조도센서 모니터링 앱��5
       J� InputBindings 5      �� 5   
   
 �� Key$ O��62    �� Command 6   �� *
CloseBtn+62   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $5��//SensorMonitorWPFApp;component/image/Images.png��6    � 5   
   $��1��6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��5q�6&   .+�5      �� -   5         ��Name$ AssemblyProduct��5      $��제품 이름��61   �� 5      -   5        $ AssemblyVersion��5      $��버전��61   �� 5      -   5        $ AssemblyCopyright��5      $��	저작권��63   �� 5      -   5        $ AssemblyCompany��5      $��회사 이름��61   5      �� 5       -   5         ��Name$ AssemblyDescription��5       $��1��63   $��85��6@   	 �� TextWrapping$	 WrapWithOverflow=�6L   
 �� 
IsReadOnly
 . $��5q�6~   �� 5!      -   5         ��Name$ BtnClick��5!      $��2��6'   $��	확인(O)��64   $��Right=�6D   $��5q�6`   5"      5#      5$      