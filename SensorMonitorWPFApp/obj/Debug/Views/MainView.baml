   M S B A M L   `   `   `  ����N  JSensorMonitorWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SensorMonitorWPFApp.ViewsSensorMonitorWPFApp.Views  5   	   (    "SensorMonitorWPFApp.Views.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	   3local'clr-namespace:SensorMonitorWPFApp.Views  5   	     � Title$  Arduino PhotoRegister��5
   	   $	��700��6'   $	��600��64    � 
ResizeMode$ NoResize=�6@    � Icon$5 //SensorMonitorWPFApp;component/image/sensor.ico��5       J� InputBindings 5      �� 5   
    �� 	Modifiers$	 Altf�67   
 �� Key$ S��6G    �� Command 6   �� *SimulStartKey+6G   �� 5   
   $	 Altf�66   $ T��6F    6   �� *SimulStopKey+6F    � 	Resources 5         ConsoleTextBox �� 
TargetType	 �� Property
 �� Value �� 
TargetType J� RenderTransformOrigin �� ScaleY(   "SensorMonitorWPFApp.Views.MainView  mv��%�  &	        &	 z    �� 5   
   " ��6'   .�5      �� 	 �@��
IsReadOnly
 . 6+   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5      �� $ 0.5,0.5&�6'   $
��Auto=�6G   z�5      �� 5   "   $ -1Q�61   .��5      �� #��z��6&   $ 0.5,0.5&�6D   .��6d   z�5   "   �� 5   &   $ -1Q�65   .��5    ;   5!      5"      5#      5%      5&        5'   
   6   5(      .��5)      ]� .+�5*   
   o� $	��Top=�6   .@�5+      m� $��_파일��6   .@�5,      m� $��열기��6    m� InputGestureText$ Ctrl+O��6'    m� Icon 5-      �� 5.      $D��>/SensorMonitorWPFApp;component/image/MenuSubItemOpen.Image.png��6    50      m� 51      $��저장��6   $ Ctrl+S��6'    52      �� 53      $D��>/SensorMonitorWPFApp;component/image/MenuSubItemSave.Image.png��6    55      �� 56      m� 57      -   5         m�Name$ MenuSubItemClose��57      $��	끝내기��65   $ Alt+F4��6B   58      m� 59      $��_시뮬레이션��6   .@�5:      m� -   5        $ SimulationStart��5:      $��시작��64   $ Alt+S��6@   m� 5;      -   5        $ SimulationStop��5;      $��중지��63   $ Alt+T��6?   5<      m� 5=      $��
_도움말��6   .@�5>      m� -   5        $ MenuSubItemInfo��5>      $��	정보...��64   5?      5@      � 5A   
   $��10q�6   $	��Top=�6    � ColumnDefinitions 5B      �� 5C      $��2* �6#   �� 5D      $��10 �6#   �� 5E      $��1* �6#   .+�5G      � $��0��6   .+�5H      �  � RowDefinitions 5I      �� 5J      $��30 �6(   �� 5K      $��* �6(   �� 5L      $	��100 �6(    5N      �� 5O      �� 5P      �� 5Q      .+�5T      �� -   5         ��Name$ ConnectTime��5T       $��0��65   $��0��6B   $��2��6R   $��연결시간 : ��5U       $��5q�6/   �� 5V      -   5         ��Name$ 	SensorCnt��5V      $��0��61   $��2��6>    �� 
IsReadOnly . 6N   �� 5W      $��포토레지스터��6   $��1��6/   $��0��6<   $��3��6L   $��0,5,0,5q�5X      .��5Y      �� .+�5Z      � -   5         �Name$ PrgValue��5Z   *   $��25��6<    � Maximum$
 1023Q�6H   �� 5[      -   5        $ 	RecvValue��5[   (   $��Center=�6;   $��0��6X   5\      5]      �� 5_      -	   5        $ RtbLog��5_      $��2��6.   $��0��6;   $��3��6K   $��0,5,0,0q�6_   $	��100��6p   " �� VerticalScrollBarVisibility$ Visible=�5`       �� TextWrapping$
 Wrap=�6D    �� AcceptsReturn .  . ��. #��[  5a   U   5c      5d      �� 5f      $��2��6   .+�5g      �� $��포트��6   .��5h      �� .+�5i      �� -
   5         ��Name$ Serial��5i   #   $��2,5,2,5q�6X    �� SelectedItem 63   �� *SelPortName+6X   �� 5j      -   5         ��Name$ ConnPort��5j   !   $��Connect��63   $��2,5,2,5q�6E   �� 5k      -   5        $ DisPort��5k   !   $��
Disconnect��62   $��2,5,2,5q�6G   �� 5l      -   5        $ 	PortValue��5l   !   $
��Port��64   $��70��6C   $��2,5,2,5q�6O   $��20(�6`   5m      5n      5o      5p        OxyPlot.Wpf.Plot  5q   
   $	��300��6   $	��Top=�6    $��10q�65      Axes 5r        OxyPlot.Wpf.LinearAxis  5s        OxyPlot.Wpf.Axis   Position$
 Left=�6!       Minimum$  0Q�61   !   Maximum! 6=   �� *YValue+  5t      $ Bottom=�6!     63   �� *Sub+! 6K   �� *XValue+"   Series" 5v        OxyPlot.Wpf.LineSeries  5w      ��6!   �� *	GrhData+5y      � 5z   
   $��150,0,150,0q�6   $	��Top=�6$    5{      �� 5|      �� 5}      .+�5      �� -   5        $ ViewAll��5      $��0��6&   $��View ALL��66   $��
15,15,15,0q�6I   $��50��6]   $	��Top=�6i   �� 5�      -   5        $
 Zoom��5�      $��1��6#   $
��ZOOM��63   $��
15,15,15,0q�6B   $��50��6V   $	��Top=�6b   5�      5�      5�      