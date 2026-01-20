
function addField(containerId, name) {
    const input = document.createElement("input");
    input.name = name;
    input.className = "form-control mb-2";
    document.getElementById(containerId).appendChild(input);
}

    document.querySelectorAll('.template-card').forEach(card => {
        card.addEventListener('click', function () {
            document.querySelectorAll('.template-card')
                .forEach(c => c.classList.remove('border-primary'));

            this.classList.add('border', 'border-primary');
            document.querySelector('[name="SelectedTemplate"]').value =
                this.dataset.template;
        });
});


// Words vs keywords
//var,let, const

//Variables


