import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import List from './components/List';
import withListLoading from './components/withListLoading';

function App() {

  const ListLoading = withListLoading(List);

  const [appState, setAppState] = useState({
    loading: false,
    repos: null,
  });

  useEffect (() => {
      setAppState({ loading: true });
      console.log("here");

      const apiUrl = 'https://localhost:49155/WeatherForecast';
      fetch(apiUrl)
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        setAppState({ loading: false, data: data });
      });
      
  }, [setAppState])


  return (
    <div className='App'>
      <div className='container'>
        <h1>My Weather</h1>
      </div>
      <div className='repo-container'>
        <ListLoading isLoading={appState.loading} weatherList={appState.data} />
      </div>
      <footer>
        <div className='footer'>
          Built{' '}
          <span role='img' aria-label='love'>
            💚
          </span>{' '}
          with by David Ball
        </div>
      </footer>
    </div>
  );
  
}

export default App;
