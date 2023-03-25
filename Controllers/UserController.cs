using Microsoft.AspNetCore.Mvc;
using SimpleAppMvc.Data;
using SimpleAppMvc.Interface;
using SimpleAppMvc.Models;

namespace SimpleAppMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            this._userInterface = userInterface;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userInterface.GetUsers();
                return View(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] UserModel user)
        {
            try
            {
                var insertUser = await _userInterface.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _userInterface.GetDetailUser(id);
                if (user == null)
                    return NotFound();
                return View(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userInterface.GetDetailUser(id);
            if (user == null)
                return NotFound();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromForm] UserModel user)
        {
            try
            {
                var updateUser = await _userInterface.UpdateUser(user);
                if (updateUser == null)
                    return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deleteUser = await _userInterface.DeleteUser(id);
                if (deleteUser == null)
                    return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }    
}