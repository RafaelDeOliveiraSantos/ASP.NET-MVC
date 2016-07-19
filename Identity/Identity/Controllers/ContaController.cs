using AulaIdentity.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

public class ContaController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastro(UsuarioRegistroModel model)
    {
        if (ModelState.IsValid)
        {
            using (var db = new Contexto())
            {
                var user = new UsuarioModel
                {
                    UserName = model.UserName,
                    Senha = model.Senha
                };

                db.Usuario.Add(user);

                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(user.UserName, false);

                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            return View(model);
        }
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            using (var db = new Contexto())
            {
                var user =
                    db.Usuario.FirstOrDefault(f =>
                        f.UserName == model.UserName
                        && f.Senha == model.Senha
                    );

                if (user != null)
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(user.UserName, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("UserName", "Usuário não encontrado");
                }
            }
        }

        return View(model);
    }
}