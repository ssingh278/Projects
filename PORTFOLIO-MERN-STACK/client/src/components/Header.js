import { React, img } from 'react'

// component for the header of the page
function Header() {
    return (

            <div className="p-5 bg-primary flex items-center justify-left">
                <img src="https://th.bing.com/th/id/OIP.0jhTZFubfC7ZPB9boosscAHaHa?w=210&h=210&c=7&r=0&o=5&dpr=1.2&pid=1.7" alt="Logo" className="h-8 w-8 mr-2" />
                <h1 className="text-secondary text-lg font-bold">SHARRY SINGH</h1>

            </div>

    )
}

export default Header