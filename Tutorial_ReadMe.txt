4 May 2017
Learning the MVVM pattern with XAML and using the MVVM Light nuget package by Laurent Bugnion.

Started looking at RelayCommands, ViewServices while trying to understand the video tutorial DesignXAMLUIBlendM04_Source from channel 9.
I saw the codebehind that Jerry Nixon was using while trying to demonstrate how to use Blend and using databinding not ONLY for 
	data but also setting up behaviors.

I could not find RelayCommand in System or any of the Microsoft libraries....so I did a search and I got:

https://msdn.microsoft.com/en-us/magazine/dn237302.aspx  this described 'previous articles'
which lead to 
https://msdn.microsoft.com/en-us/magazine/jj694937.aspx and this mentioned the MVVM pattern
which lead to 
https://msdn.microsoft.com/en-us/magazine/jj651572.aspx
 which lead to the MVVM Light tool kit which is a Nuget package...so I went looking for an MVVM Light tutorial

 which lead to 
A) http://dotnetpattern.com/mvvm-light-toolkit-example

		Some of the steps:
		1) MVVMLightLibs v5.3.0 is what was the latest stable release as of 4 May 2017
		2) Because XAML excells with DataBinding, all models and viewModels need to use ObservableObjects (sub library of the MVVMLight)
				create all models and viewModels with these inheritances
		3) Need to create a Locator which uses the System.ServiceLocator


B) Now I'm going to http://www.dotnetcurry.com/wpf/1037/mvvm-light-wpf-model-view-viewmodel
		to add some EventToCommands....on the WPF elements that do not by default support the Command property.  In this article, 
		the author adds a textbox and wants to use it for searching a collection.  A textbox does not have a 'command' property.
		Subsection "Defining Commanding on UI Elements not having the Command property" goes over this.

		i) GalaSoft.MvvmLight.Command.EventToCommand allows binding any event  of any FrameworkElement to System.Windows.Input.ICommand
		ii) doing this a bit differnt...because I starte with dotnetpattern example..but similar.

		Notes:  didn't really work the way the tutorial was saying...too much work, but the tutorial was from 2012.
						In vs 2015 (and using blend at the same time for the UI..realy cool, btw) it was much less typing.
							steps
								1) Added xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity" the intellisense is sweet
										The Interaction.Triggers is what ties the events of an object to commands in the view model
								2) Added the textbox.text property to watch ...for the search functionality
								3) Added the property in the view model
								4) Added the command to the view model
								5) Used blend to tie them together with binding...SWEET!
								6) Changed the event to watch for from TextChanged to LostFocus
								7) Found the problem with TextChanged.  I didn't have the UpdateSourceTrigger set for the text box
										ie. <TextBox Width="150" Height="25" Margin="0,5,0,0" Background="#FFE3E5B0" 
														Text="{Binding EmpTofind, UpdateSourceTrigger=PropertyChanged}">
										without the updateSourceTrigger set, the underlying bound field 'EmpToFind' does not get
										updated as you type


				should have found this post first http://blog.galasoft.ch/posts/2009/11/mvvm-light-toolkit-v3-alpha-2-eventtocommand-behavior/
				It's from Laurent Bugnion the writer of MVVM Light Lib....woo hoo


9 May 2017
I got the stuff working over the weekend...pretty cool.

Started a new tutorial: https://www.tutorialspoint.com/xaml/

Started running into the problem of having more stuff (tutorial info) that doesn't match the other stuff I've done so far...
Wanted to organize it a bit, so I wanted to figure out how to navigate within the app.....Window has pages....
Adding Tree view (did that little bit in the main window and added a frame ..this displays the other pages....)

11 May 2017
Had to search for Exporting html to excel.  Rememberd MPC was doing something like that but could not remember exactly where....wanted 
to use Grep, but really shouldn't install 'unapproved' tools.  So, after finding the file from doing a solution search with vs, decided
to see if dos had something...I think that is what grep for windows uses....dos Findstr command  https://technet.microsoft.com/en-us/library/bb490907.aspx.
Little google and I'm calling it from c#.  GrepToy.

12 May 2017
Now I want to validate the fields in GrepToy to make sure there is some text in all text boxes before seach is enabled.
http://web.archive.org/web/20130111200333/http://www.switchonthecode.com:80/tutorials/wpf-tutorial-binding-validation-rules
No kidding...had to go back to 2013 to get the site...

Turns out that it wasn't all that difficult and didn't have to do all the stuff that the wayback archived page said.
Just had to find the right examples.

GrepToy
	DOS FindStr required params (DirectoryToSearch, SearchString, fileExtension)
	Added Field Validation to textboxes (Used a textBlock with Text="{Binding ElementName=SearchDirBox, Path=(Validation.Errors),Converter={StaticResource EtoMConverter}} 
																				to display the errors from the Custom ErrorsToStringConverter
																				Saw an example where the put the TextBlock within a Border element 
																				and gave a CornerRadius="10" Height="20" Width="20" makes a ball)

	Tied in the validation in the page codebehind in the Page_Loaded method 
					with the 'execute' command with a call: SearchDirBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
					Forced the field validations in Page_Loaded  (http://stackoverflow.com/questions/483419/force-validation-on-bound-controls-in-wpf 
					but had to instantiate each bound backing property = string.empty)


