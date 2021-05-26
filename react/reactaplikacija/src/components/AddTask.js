import {useState} from 'react'

const AddTask = ({ onAdd }) => {
    const[text1, setName] = useState('')
    const[text2, setCategory] = useState('')

    const onSubmit = (e) => {
        e.preventDefault()

        if(!text1 || !text2){
            alert('Molimo vas unesite tekst')
            return
        }

        onAdd({text1, text2})
        setName('')
        setCategory('')
    }
    return (      
          <form className='add-form' onSubmit={onSubmit}>
              <div className = 'form-control'>
                <label >Ime</label>
                <input 
                type = 'text' 
                placeholder='Add Name' 
                value={text1} 
                onChange={(e) => setName(e.target.value)}/>
              </div>
              <div className = 'form-control'>
                <label >Kategorija</label>
                <input 
                type = 'text' 
                placeholder='Add Category' 
                value={text2} 
                onChange={(e) => setCategory(e.target.value)}/>
              </div>

              <input 
              type = 'submit' 
              placeholder='Save Task'
              className ='btn btn-block'/>
          </form>

    )
}

export default AddTask
