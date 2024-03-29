/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////Author: Sharry Singh///////////////////////////////////////////////////////////////
/////////////////////////////Email: Singh21Sharry@gmail.com//////////////////////////////////////////////////////
export const Task = (props) => {

    return (<div className="task_content">
        <h1 style={{ backgroundColor: props.isComplete ? "yellowgreen" : "red" }}>{props.taskName}</h1>
        <button onClick={()=>props.completeTask(props.id)}>Complete</button>
        <button onClick={()=>props.deleteTask(props.id)}>X</button>
    </div>);
}