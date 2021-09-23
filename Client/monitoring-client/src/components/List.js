import React from 'react';
const List = (props) => {
  const { weatherList } = props;
  if (!weatherList || weatherList.length === 0) return <p>No weather, sorry</p>;
  return (
    <ul>
      <h2 className='list-head'>Weather</h2>
      {weatherList.map((weather) => {
        return (
          <li key={weather.id} className='list'>
            <span className='repo-text'>{weather.city} </span>
            <span className='repo-description'>{weather.high}</span>
            <span className='repo-description'>{weather.low}</span>
          </li>
        );
      })}
    </ul>
  );
};
export default List;