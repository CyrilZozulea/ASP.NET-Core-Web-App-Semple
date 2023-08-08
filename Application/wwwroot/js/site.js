var myModalEl = document.getElementById('modelview')
myModalEl.addEventListener('hidden.bs.modal', function (event) {
    const element = document.getElementById("partialView");
    element.remove();
})

