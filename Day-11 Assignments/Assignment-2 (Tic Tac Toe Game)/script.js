let player1chance = true;
let player2chance = false;
let count = 0;
let gameOver = false;

let arr = [
    ['', '', ''],
    ['', '', ''],
    ['', '', '']
];

let player1opt;
let player2opt;

function reset() {
    let result = document.querySelector('.result');
    let boxes = document.querySelectorAll('.game-item');

    for (let i = 0; i < 9; i++) {
        boxes[i].innerHTML = '';
    }

    arr = [
        ['', '', ''],
        ['', '', ''],
        ['', '', '']
    ];

    count = 0;
    gameOver = false;
    player1chance = true;
    player2chance = false;
    result.innerHTML = '';
}



function checkwin() {
    let result = document.querySelector('.result');

    for (let i = 0; i < 3; i++) {

        if (arr[i][0] === arr[i][1] && arr[i][1] === arr[i][2] && arr[i][0] !== '') {
            result.innerHTML = (player1opt === arr[i][0]) ? "Player1 has won" : "Player2 has won";
            gameOver = true;
            return;
        }

        
        if (arr[0][i] === arr[1][i] && arr[1][i] === arr[2][i] && arr[0][i] !== '') {
            result.innerHTML = (player1opt === arr[0][i]) ? "Player1 has won" : "Player2 has won";
            gameOver = true;
            return;
        }
    }

    // Diagonal check
    if (arr[0][0] === arr[1][1] && arr[1][1] === arr[2][2] && arr[0][0] !== '') {
        result.innerHTML = (player1opt === arr[0][0]) ? "Player1 has won" : "Player2 has won";
        gameOver = true;
        return;
    }

    if (arr[0][2] === arr[1][1] && arr[1][1] === arr[2][0] && arr[0][2] !== '') {
        result.innerHTML = (player1opt === arr[0][2]) ? "Player1 has won" : "Player2 has won";
        gameOver = true;
        return;
    }

    // Draw
    if (count === 9) {
        result.innerHTML = "Game Draw";
        gameOver = true;
    }
}

function boxSelected(c) {

    
    if (gameOver) return;

    player1opt = document.querySelector('.player1opt').value;
    player2opt = document.querySelector('.player2opt').value;

    if (player1opt === player2opt) {
        alert("Choose a different option Player1 / Player2");
        return;
    }

    let row = Math.floor((c - 1) / 3);
    let col = (c - 1) % 3;

    let dtag = document.querySelector(`.game-item-${c}`);

    if (dtag.innerHTML !== '') {
        alert("Box has already been selected");
        return;
    }

    if (player1chance) {
        arr[row][col] = player1opt;
        dtag.innerHTML = player1opt === 'x' ? '✖️' : '⭕';
        player1chance = false;
        player2chance = true;
    } else {
        arr[row][col] = player2opt;
        dtag.innerHTML = player2opt === 'x' ? '✖️' : '⭕';
        player1chance = true;
        player2chance = false;
    }

    count++;
    checkwin();
}
