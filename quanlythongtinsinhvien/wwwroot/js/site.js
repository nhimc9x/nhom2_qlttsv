// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var categoryPresent = document.querySelectorAll('.default-layout nav a')
var ctProject = document.getElementById('ct-project-id')
var ctAbout = document.getElementById('ct-about-id')
//var ctContact = document.getElementById('ct-contact-id')
categoryPresent[0].addEventListener('click', () => { document.documentElement.scrollTop = 0 })
categoryPresent[1].addEventListener('click', () => { document.documentElement.scrollTop = 420 })
categoryPresent[2].addEventListener('click', () => { document.documentElement.scrollTop = 420 + ctProject.clientHeight })
categoryPresent[3].addEventListener('click', () => { document.documentElement.scrollTop = 420 + ctProject.clientHeight + ctAbout.clientHeight })
//categoryPresent[3].addEventListener('click', () => { document.documentElement.scrollTop = 420 + ctProject.clientHeight + ctAbout.clientHeight })

//window.onscroll = (e) => backToTop()
//function backToTop() {
   // let vitri = document.documentElement.scrollTop
  //  console.log('Vị trí: ', vitri)
  //  if (vitri >= 420) categoryPresent[1].classList.add('ct-active')
//}