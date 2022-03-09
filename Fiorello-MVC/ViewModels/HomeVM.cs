using Fiorello_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderDetail Detail { get; set; }
    }
}
