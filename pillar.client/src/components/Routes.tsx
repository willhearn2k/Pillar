import * as React from 'react';
import { Route } from 'react-router';
import Home from './Home';
import Counter from './Counter';
import FetchData from './FetchData';
import PlayerList from './player/player-list';

export default () => (
    <div>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
        <Route path='/player' component={PlayerList} />
    </div>
);