function colorize() {
   const trItemForColorize = document.querySelectorAll('table tr:nth-child(2n)')

   //trItemForColorize.forEach(element => element.style.backgroundColor = 'Teal');

    for(let element of trItemForColorize){
        element = element.style.backgroundColor = 'Teal';
    }

}