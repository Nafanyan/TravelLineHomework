﻿
namespace Shop.Controllers
{
    internal interface IController
    {
        public void Start();

        public void NextController(IController controller);

    }
}
