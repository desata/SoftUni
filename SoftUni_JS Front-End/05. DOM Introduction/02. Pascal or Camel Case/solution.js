function solve() {
  const firstTextElement = document.getElementById('text').value;
  const secondTextElement = document.getElementById('naming-convention').value;
  const resultElement = document.getElementById('result');
  let result;

  if (secondTextElement == 'Camel Case') {
    let arr = firstTextElement.split(' ');
    result = arr[0].toLowerCase();
    for (let i = 1; i < arr.length; i++) {
      result += arr[i];
    }

    result = arr;
  }
  else if (secondTextElement == 'Pascal Case') {
    result = 'two'
  }
  else {
    result = 'Error!';
  }

  resultElement.textContent = result;

}