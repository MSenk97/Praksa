import { useState } from 'react'
import Header from './components/Header'
import Tasks from './components/Tasks'
import AddTask from './components/AddTask'

const App = () => {
  const[tasks, setTasks] = useState(
    [
      {
        id: 1,
        Ime: 'Samsung Galaxy S5',
        Kategorija: 'Mobiteli',
    },
    {
        id: 2,
        Ime: 'Golf 2',
        Kategorija: 'Automobili',
    },
    {
        id: 3,
        Ime: 'Računalo',
        Kategorija: 'Informatika',
    },
    ] 
    )

  // ADD ADVERT
  const addTask = (task) => {
      const id = Math.floor(Math.random() * 10000) + 1

      const newTask = {id, ...task}
      setTasks([...tasks, newTask]) //ispis ne radi iz nepoznatog razloga

      console.log(newTask)

  }
  // DELETE ADVERT
  const deleteTask = (id) => {
    setTasks(tasks.filter((task) => task.id !== id))
  }

  return (
    <div className="container">
      <Header />
      <AddTask onAdd={addTask} />
      {tasks.length > 0 ? <Tasks tasks={tasks} onDelete={deleteTask}/> : 'Nema oglasa za prikaz'}
    </div>
  );
}

export default App
