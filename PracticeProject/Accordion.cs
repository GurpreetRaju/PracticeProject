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

namespace PracticeProject
{
    /// <summary>
    /// Custom control
    ///     <PracticeProject:Accordion/>
    /// </summary>
    public class Accordion : Grid
    {
        static Accordion()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Accordion), new FrameworkPropertyMetadata(typeof(Accordion)));
        }
        
        public override void EndInit()
        {
            base.EndInit();
            UpdateAccordionLayout();
        }


        public void UpdateAccordionLayout()
        {
            RowDefinitions.Clear();
            ColumnDefinitions.Clear();
            int i = 0;
            foreach(UIElement child in Children)
            {
                if (child is AccordionItem && !(child as AccordionItem).IsExpanded)
                    ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                else
                    ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                Grid.SetColumn(child, i);
                i++;
            }
            InvalidateMeasure();
        }

    }
}
