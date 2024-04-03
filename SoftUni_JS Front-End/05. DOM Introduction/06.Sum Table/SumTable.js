function sumTable() {
    const elementsByTr = document.querySelectorAll('tr td:last-child:not(#sum)');
    const sumElement = document.getElementById('sum');
    let sum = 0;

    for (let element of elementsByTr) {
       sum += Number(element.textContent);
    }
    sumElement.textContent = sum;
}