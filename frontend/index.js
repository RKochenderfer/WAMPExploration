'use strict'

const responseListSelector = document.getElementById('response-list')
const pubSubListSelector = document.getElementById('pubSub-list')
const pingSelector = document.getElementById('ping')

const url = 'ws://127.0.0.1:8080/ws'
const realm = 'realm1'
const connection = new autobahn.Connection({ url: url, realm: realm })

connection.onopen = async (session) => {
    pingSelector.onclick = async () => {
        const result = await session.call('com.arguments.ping', [])
        responseListSelector.innerHTML = `${responseListSelector.innerHTML}<li class='list-group-item'>${result}</li>`
    }

    console.log(`Connected`)
} 

connection.open()

