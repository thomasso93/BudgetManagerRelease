   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   BudgetManager   BudgetManager.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     (ignorehttp://www.ignore.com     $	��645��$	��931��  � Title$  BudgetManager�� � 	Resources  �� MergedDictionaries �� Source��  �� $ Skins/MainSkin.xaml?�%     � DataContext ��  �� IsAsync .  �� Path$
 Main�   Locator �� Source# [  .���� $
��Left=�$	��615��$	��Top=�$	��921��.@��� $��Wydatki��.��� ���	#FFE5E5E5$��-3,-2,-11,-7q� � ColumnDefinitions �� $��6* ��� $
��155* ��� $
��764* �.+�]� -   	 ]�Name$	 	dockPanel��$
��Left=�$	��592����.  $	��Top=�$	��905��$��-7,0,0,0q�$��3���� -   
 ��Name$
 expenseNameTxtBox��$
��Left=�$��23��$��
526,13,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��211��$��2������ *ExpenseName+�� -    ��Name$ categoryBox��$
��Left=�$��
526,51,0,0q�$	��Top=�$	��211��$��2�� �� Text �� *CategoryName+�� $��Nazwa:��$
��Left=�$��
381,10,0,0q�$	��Top=�$��86��$��2���� $��
Kategoria:��$
��Left=�$��
381,47,0,0q�$	��Top=�$��86��$��2���� -    ��Name$ 
saveButton��$��Zapisz��$
��Left=�$��381,255,0,0q�$	��Top=�$	��356�� �� 	IsDefault . {�. $��47��$��2������ *NewExpenseCommand+�� -   $ 
loadButton��$��Wczytaj dane...��$
��Left=�$��
22,544,0,0q�$	��Top=�$	��226��$��31��$��1��$��2������ *LoadExpenseData+�� $��Kwota:��$
��Left=�$��
381,87,0,0q�$	��Top=�$��86��$��2���� -   $
 expenseAmountBox��$
��Left=�$��23��$��
526,87,0,0q�$
 Wrap=�$	��Top=�$	��211��$��2������ *AmountValue+�� $
��Data��$
��Left=�$��381,124,0,0q�$	��Top=�$��86��$��2���� -   $ 
editButton��$��Edytuj��$
��Left=�$��105,544,0,0q�$	��Top=�$	��226��$��31��$��2������ *
EditData+&   System.Windows.Controls.DataGrid  $
��Left=�$��9,15,0,0q�$	��Top=�$	��517��$	��508��   AutoGenerateColumns .  $��1��$��2������ *
Expenses+ �� SelectedItem �� *SelectedExpense+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   SortMemberPath$ Id��   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 35    
IsReadOnly .    CellTemplate �� .R��� ���� *Id+  $
 Name��$ Nazwa wydatku��$	 175  .  �� .R��� ���� *Name+  $ Category��$ 	Kategoria��$	 100  .  �� .R��� ���� *
Category+  $ Amount��$ Kwota��$	 100  �� .R��� ���� *Amount+  $
 Date��$
 Data��$ 90  .  �� .R��� ���� *Date+�� -   $
 expensDateBox��$
��Left=�$��23��$��526,122,0,0q�$
 Wrap=�$	��Top=�$	��211��$��2������ *	DateValue+�� $��	Przychody��.��� ���	#FFE5E5E5$��-3,-3,-11,-6q� �� $��6* ��� $
��919* �.+�]� -	   $	 
edockPanel��$
��Left=�$	��592����.  $	��Top=�$	��905��$��	-2,2,0,-2q�$��2���� -
   $
 incomeNameTxtBox��$
��Left=�$��23��$��
681,13,0,0q�$
 Wrap=�$	��Top=�$	��211��$��1������ *
IncomeName+�� -   $ incomeCategoryBox��$
��Left=�$��
681,51,0,0q�$	��Top=�$	��211��$��1�� �� *CategoryIncomeName+�� $��Nazwa:��$
��Left=�$��
536,10,0,0q�$	��Top=�$��86��$��1���� $��
Kategoria:��$
��Left=�$��
536,47,0,0q�$	��Top=�$��86��$��1���� -   $ saveIncomeButton��$��Zapisz��$
��Left=�$��536,197,0,0q�$	��Top=�$	��356�� . {�. $��47��$��1������ *NewIncomeCommand+�� -   $ incomeLoadButton��$��Wczytaj dane...��$
��Left=�$��
22,544,0,0q�$	��Top=�$	��476��$��31��$��1������ *LoadIncomeData+�� $��Kwota:��$
��Left=�$��
536,89,0,0q�$	��Top=�$��86��$��1���� -   $
 incomeAmountBox��$
��Left=�$��23��$��
681,90,0,0q�$
 Wrap=�$	��Top=�$	��211��$��1������ *AmountIncomeValue+�� $
��Data��$
��Left=�$��536,128,0,0q�$	��Top=�$��86��$��1��  $
��Left=�$��9,15,0,0q�$	��Top=�$	��517��$	��508�� .  $��1������ *	Incomes+ �� *SelectedIncome+   $ Id��$ ID��$ 35  .  �� .R��� ���� *Id+  $
 Name��$ Nazwa wydatku��$	 175  .  �� .R��� ���� *Name+  $ Category��$ 	Kategoria��$	 100  .  �� .R��� ���� *
Category+  $ Amount��$ Kwota��$	 100  �� .R��� ���� *Amount+  $
 Date��$
 Data��$ 90  .  �� .R��� ���� *Date+�� -   $
 incomeDateBox��$
��Left=�$��23��$��681,130,0,0q�$
 Wrap=�$	��Top=�$	��211��$��1������ *DateIncomeValue+�� $��
Statystyki��.��� ���	#FFE5E5E5 �� $	��74* ��� $
��837* �.+��� $��STATYSTYKI:��$
��Left=�$	��Top=�$��200,-12,0,0q�$	��106��$	��474��$��48(�$��
ExtraBlack"�$��Oblique$�$��1���� $��Przychody wg kategorii:��$
��Left=�$��
46,122,0,0q�$	��Top=�$��1��  $
��Left=�$��
14,152,0,0q�$	��Top=�$	��197��$	��410�� .     CanUserAddRows .  $��2������ *DisplayIncomeCategories+   $
 Name��$ Nazwa kategorii��$	 200  .  �� .R��� ���� *Name+  $ Amount��$ Kwota��$	 200  �� .R��� ���� *Amount+�� $'��!Największe przychody w tym roku:��$
��Left=�$��
46,367,0,0q�$	��Top=�$��1��  $
��Left=�$��
14,397,0,0q�$	��Top=�$	��176��$	��410�� .  $��2�� .  ���� *IncomesYear+   $
 Name��$ Nazwa przychodu��$	 130  .  �� .R��� ���� *Name+  $ Category��$ 	Kategoria��$	 100  .  �� .R��� ���� *
Category+  $ Amount��$ Kwota��$	 100  �� .R��� ���� *Amount+  $
 Date��$
 Data��$ 70  .  �� .R��� ���� *Date+�� $��Wydatki wg kategorii:��$
��Left=�$��505,122,0,0q�$	��Top=�$��1��  $
��Left=�$��399,152,0,0q�$	��Top=�$	��197��$	��410�� .   .  $��1������ *DisplayExpenseCategories+   $
 Name��$ Nazwa kategorii��$	 200  .  �� .R��� ���� *Name+  $ Amount��$ Kwota��$	 200  �� .R��� ���� *Amount+  $
��Left=�$��399,397,0,0q�$	��Top=�$	��176��$	��410�� .   .  $��1������ *ExpensesYear+   $
 Name��$ Nazwa wydatku��$	 130  .  �� .R��� ���� *Name+  $ Category��$ 	Kategoria��$	 100  .  �� .R��� ���� *
Category+  $ Amount��$ Kwota��$	 100  �� .R��� ���� *Amount+  $
 Date��$
 Data��$ 70  .  �� .R��� ���� *Date+�� $%��Największe wydatki w tym roku:��$
��Left=�$��505,367,0,0q�$	��Top=�$��1���� $
��Left=�$��49��$��
55,119,0,0q�$	��Top=�$��61��$��Data\green_arrow.png�� J� RenderTransformOrigin$ 0.717,0.802&�$��2��z�V� .~��� �� ��  �� Angle$ -180.614Q�T�  T� X$ -43.726Q� T� Y$ -60.162Q��� $
��Left=�$��45��$��
743,95,0,0q�$	��Top=�$��69��$��Data\red_arrow.png��$��1���� $��Pokaż��$
��Left=�$��
334,59,0,0q�$	��Top=�$��75��$��1������ *ShowCommand+