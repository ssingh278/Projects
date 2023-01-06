/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////Author: Sharry Singh///////////////////////////////////////////////////////////////
/////////////////////////////Email: Singh21Sharry@gmail.com//////////////////////////////////////////////////////
import './App.css';
import { useState } from 'react'
import { Task } from './task'

function App() {
  ///////////////////////////////////////////////Variables///////////////////////////////////////////////
  /* for current typed task by user */
  let [newTask, updateNewTask] = useState("");
  let [todoList, updateTodoList] = useState([]);


  ////////////////////////////////////////////////////////////////////////////////////////////////////////
  //////////////////////////////////////Functions/////////////////////////////////////////////////////////

  /* this function will change task text */
  function changeText(event) {
    updateNewTask(event.target.value);
  }


  ////////////////////////////////////////////////////////////////////////////////////////////////////////
  /* this function will add tast into list as well as clear listbox*/
  function addToList() {

    const task = {
      id: (todoList.length === 0) ? 1 : (todoList[todoList.length - 1].id + 1),
      taskName: newTask,
      isComplete: false,
    }
    /* adding to list by using spread operator */
    updateTodoList([...todoList, task]);

    /* selecting textbox by class name */
    const tbx = document.querySelector(".tbx");

    /* alert for the user that task has been added to the list */
    alert(`Task ${tbx.value} has been added to Todo-List`);

    /* clearing textbox */
    tbx.value = "";

    /* updating task value */
    updateNewTask("");

  }
  ////////////////////////////////////////////////////////////////////////////////////////////////////////
  function completeTask(id) {
    updateTodoList(
      todoList.map((task) => {
        if (task.id === id) {
          return { ...task, isComplete: true };
        } else {
          return task;
        }
      })
    );
  }
  /////////////////////////////////////////////////////////////////////////////////////////////////////////
  function deleteTask(id) {
    updateTodoList(todoList.filter((task) => task.id !== id))
  }
  ////////////////////////////////////////////////////////////////////////////////////////////////////////


  ///////////////////////////////////////main HTML////////////////////////////////////////////////////////
  ////////////////////////////////////////////////////////////////////////////////////////////////////////
  return (
    <div className="App">
      { /* -------------------------------Header Div-------------------------------------------------- */}

      <h1 className='heading'>Todo-List</h1>

      { /* ------------------------------------------------------------------------------------------- */}
      {/* ----------------------------input text div-------------------------------------------------- */}
      <div className='input-content'>
        <div className='input-items'>
          <input type={"text"} onChange={changeText} className={"tbx"} />
          <button onClick={addToList}>Add Task</button>
        </div>
        <div className='task'>
          <h2>Task : {newTask.task}</h2>
        </div>
      </div>

      { /* ------------------------------------------------------------------------------------------- */}
      {/* ----------------------------display list---------------------------------------------------- */}

      <div>
        <div className='task-status' >
          <label className='total-task'>Total Task : {todoList.length}</label>
        </div>

        <div className='list-content'>

          {todoList.map((task) => {
            return <Task
              taskName={task.taskName}
              isComplete={task.isComplete}
              id={task.id}
              completeTask={completeTask}
              deleteTask={deleteTask}
            />
          })}
        </div>
      </div>


    </div>

  );
}

export default App;
