using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieController : Controller
    {
        private BaseDonnees _baseDonnees { get; set; }

        public ZombieController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<Zombie> zombiesList = _baseDonnees.Zombies.ToList();
            return View(zombiesList);

        }

        public IActionResult Create()
        {
            ViewBag.ZombieTypes = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName", null);
            ZombieVM zombieVM = new ZombieVM();

            zombieVM.ZombieTypeSelectList = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName");

            return View(zombieVM);
        }

        

        [HttpPost]
        public IActionResult Create(Zombie zombie ZombieVM zombieVM)
        {
            //Si le modèle est valide le zombie est ajouté et nous sommes redirigés vers index.
            if (ModelState.IsValid)
            {
                _baseDonnees.Zombies.Add(zombie zombieVM.Zombie);
                _baseDonnees.SaveChanges();
                TempData["Success"] = $"Zombie {zombie.Name zombieVM.Zombie.Name} added";
                return this.RedirectToAction("Index");
            }
            //Il faut repopuler le zombieType dans le ViewBag
            //Aller chercher le ZombieType sélectionné, rappel 2W5 Linq
            ZombieType selectedZombieType = _baseDonnees.ZombieTypes.Where(zt => zt.Id == zombie.ZombieTypeId).SingleOrDefault();
            zombie.ZombieType = selectedZombieType;

            ViewBag.ZombieTypes = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName", selectedZombieType);

            zombieVM.ZombieTypeSelectList = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName");

            return View(zombie zombieVM); //retourne l'objet pour avoir les données 
        }


    }

        public class ZombieVM
        {
            // Pour Upsert 1 zombie à la fois
            public Zombie Zombie { get; set; }


            public SelectList? ZombieTypeSelectList { get; set; }
        }

    }
}
